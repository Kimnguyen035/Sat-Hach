using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;
using WebApplication.Repositories;
using WebModels;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = UserRoles.Admin)]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var ListUser = await _userRepository.GetAllUser();

            return Ok(ListUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetail(long id)
        {
            var user = await _userRepository.GetUserDetail(id);

            if (user == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUser req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            User user = new User()
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                UserName = req.UserName,
                Email = req.Email,
                NormalizedUserName = req.UserName.ToUpper(),
                NormalizedEmail = req.Email.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Created_at = DateTime.UtcNow,
                Updated_at = DateTime.UtcNow
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, req.PassWordHash);

            var userCreate = await _userRepository.CreateUser(user);

            return CreatedAtAction(nameof(GetUserDetail), new { id = userCreate.Id }, userCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedUser(long id, [FromBody] UpdateUser req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userRepository.GetUserDetail(id);

            if (user == null)
            {
                return NotFound($"{id} is not found");
            }

            user.FirstName = req.FirstName;
            user.LastName = req.LastName;
            user.UserName = req.UserName;
            user.Email = req.Email;
            user.PasswordHash = _passwordHasher.HashPassword(user, req.PassWordHash);
            user.Updated_at = DateTime.UtcNow;

            var userUpdate = await _userRepository.UpdateUser(user);
            return Ok(new Usered
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                UserName = userUpdate.UserName,
                PassWordHash = userUpdate.PasswordHash,
                Email = userUpdate.Email,
                Updated_at = userUpdate.Updated_at,
                Id = userUpdate.Id
            });
        }
    }
}
