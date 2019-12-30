using System;
using System.Threading.Tasks;
using CustomServer.Data;
using CustomServer.Dtos;
using CustomServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo){
            _repo=repo;
        }

        //https://localhost:5001/api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto){

            if(await _repo.UserExists(userForRegisterDto.email))
                return BadRequest("this email is already taken");
            
            var userToCreate = new User
            {
                email = userForRegisterDto.email

            };
            var createdUser = _repo.Register(userToCreate, userForRegisterDto.password);
            return StatusCode(201);
            //return Ok();
        }
        
    }
}