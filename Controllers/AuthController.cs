using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomServer.Data;
using CustomServer.Dtos;
using CustomServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CustomServer.Controllers
{

    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {


        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController( 
        IConfiguration config, 
        IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager){
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //https://localhost:5001/api/auth/register
        // [EnableCors("MyAllowSpecificOrigins")]
        // [HttpPost("register")]
        // public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto){

        //     // if(await _repo.UserExists(userForRegisterDto.email))
        //     //     return BadRequest("this email is already taken");
            
        //     // var userToCreate = new User
        //     // {
        //     //     email = userForRegisterDto.email

        //     // };
        //     //var createdUser =await _repo.Register(userToCreate, userForRegisterDto.password);
        //     return StatusCode(201);
        //     //return Ok();
        // }

        //https//localhost:5001/api/auth/login
        //[EnableCors("MyAllowSpecificOrigins")]
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto){

            Console.WriteLine("ok");
            var logedinUser = await _userManager.FindByEmailAsync(userForLoginDto.email);
           
            // var result = await _signInManager.CheckPasswordSignInAsync(logedinUser, userForLoginDto.password, false);

            // if(result.Succeeded){
            //     var user = _mapper.Map<UsersListDto>(logedinUser);

            //     return Ok(new{
            //         token = GenerateJwtToken(logedinUser),
            //         user
            //      });
            // }

            //  Console.WriteLine("asfaafsa");
            // return Unauthorized();

            return Ok("ok man");
            
        }

        private string GenerateJwtToken(User user)
        {
             var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                };

                //Create security key
                var key = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(_config.GetSection("AppSettings:Token").Value));
                
                //Hash the key
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                //Add other properties
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddSeconds(1200),
                    SigningCredentials = creds
                };
                //create token using tokenhandler
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

               return tokenHandler.WriteToken(token); 
        }
        
    }
}