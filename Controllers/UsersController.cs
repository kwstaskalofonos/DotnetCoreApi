using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using customserver.Data;
using CustomServer.Dtos;
using CustomServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace customserver.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IDatingRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }

        //[HttpGet("getusers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var returnUsers = _mapper.Map<IEnumerable<UsersListDto>>(users); 
            return Ok(returnUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            User user = await _repo.GetUser(id);
            return Ok(_mapper.Map<UsersListDto>(user));
        }
        
    }
}