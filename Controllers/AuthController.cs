using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CustomServer.Data;
using CustomServer.Dtos;
using CustomServer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CustomServer.Controllers
{

    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _repo;

        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config){
            _repo=repo;
            _config = config;
        }

        //https://localhost:5001/api/auth/register
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto){

            if(await _repo.UserExists(userForRegisterDto.email))
                return BadRequest("this email is already taken");
            
            var userToCreate = new User
            {
                email = userForRegisterDto.email

            };
            var createdUser =await _repo.Register(userToCreate, userForRegisterDto.password);
            return StatusCode(201);
            //return Ok();
        }

        //https//localhost:5001/api/auth/login
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto){

            var logedinUser = await _repo.Login(userForLoginDto.email, userForLoginDto.password);

            if(logedinUser==null){
                return Unauthorized();
            }
            
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, logedinUser.Id.ToString()),
                new Claim(ClaimTypes.Name, logedinUser.email)
            };

            //Create security key
            var key = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(_config.GetSection("AppSettings:Token").Value));
            
            //Hash the key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            //Add other properties
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(1),
                SigningCredentials = creds
            };
            //create token using tokenhandler
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new{
                token = tokenHandler.WriteToken(token)
            });
        }
        
    }
}