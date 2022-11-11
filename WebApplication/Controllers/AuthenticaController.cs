using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entities;
using WebApplication.Repositories;
using WebModels;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public AuthenticaController(IConfiguration configuration, UserManager<User> userManager
            , IUserRepository userRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    claim.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(1);

                var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claim,
                        expires: expiry,
                        signingCredentials: creds
                    );

                return Ok(new LoginResponse { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser regis)
        {
            var userExists = await _userManager.FindByNameAsync(regis.UserName);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
                {
                    Status = "Error",
                    Message = "User already exists!"
                });
            }

            User user = new User()
            {
                FirstName = regis.FirstName,
                LastName = regis.LastName,
                Email = regis.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = regis.UserName,
                NormalizedUserName = regis.UserName.ToUpper(),
                NormalizedEmail = regis.Email.ToUpper(),
                Created_at = DateTime.UtcNow,
                Updated_at = DateTime.UtcNow
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, regis.PassWordHash);

            var result = await _userRepository.CreateUser(user);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
                {
                    Status = "Error",
                    Message = "User creation failed! Please check user details and try again."
                });
            }

            var rolead = await _userManager.GetRolesAsync(user);

            if (rolead == null)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            return Ok(new RegisterResponse { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUser regis)
        {
            var userExists = await _userManager.FindByNameAsync(regis.UserName);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
                {
                    Status = "Error",
                    Message = "User already exists!"
                });
            }

            User user = new User()
            {
                FirstName = regis.FirstName,
                LastName = regis.LastName,
                Email = regis.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = regis.UserName,
                NormalizedUserName = regis.UserName.ToUpper(),
                NormalizedEmail = regis.Email.ToUpper(),
                Created_at = DateTime.UtcNow,
                Updated_at = DateTime.UtcNow
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, regis.PassWordHash);

            var result = await _userRepository.CreateUser(user);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
                {
                    Status = "Error",
                    Message = "User creation failed! Please check user details and try again."
                });
            }

            var rolead = await _userManager.GetRolesAsync(user);

            if (rolead == null)
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new RegisterResponse { Status = "Success", Message = "User created successfully!" });
        }
    }
}
