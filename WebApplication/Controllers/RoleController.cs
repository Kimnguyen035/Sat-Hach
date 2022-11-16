using Microsoft.AspNetCore.Http;
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
    public class RoleController : ControllerBase
    {
        private IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var ListRole = await _roleRepository.GetAllRole();

            return Ok(ListRole);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleDetail(Guid id)
        {
            var role = await _roleRepository.GetRoleId(id);

            if (role == null)
            {
                return NotFound($"{id} is not found");
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Role role = new Role()
            {
                Name = roleName,
                NormalizedName = roleName,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
            };

            var roleCreate = await _roleRepository.CreateRole(role);

            return CreatedAtAction(nameof(GetRoleDetail), new { id = roleCreate.Id }, roleCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedUser(Guid id, [FromBody] string roleName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var role = await _roleRepository.GetRoleId(id);

            if (role == null)
            {
                return NotFound($"{id} is not found");
            }

            role.Name = roleName;
            role.Updated_at = DateTime.Now;

            var roleUpdate = await _roleRepository.UpdateRole(role);
            return Ok(new Roled
            {
                roleName = roleUpdate.Name,
                Decription = roleUpdate.Decription,
                Updated_at = roleUpdate.Updated_at,
                Id = roleUpdate.Id
            });
        }
    }
}
