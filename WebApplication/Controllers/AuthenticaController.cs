using Microsoft.AspNetCore.Authorization;
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
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public AuthenticaController(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager
            , IUserRepository userRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null) return BadRequest(new LoginResponse { Successful = false, Error = "Username and password are invalid." });

            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

            if (!result.Succeeded) return BadRequest(new LoginResponse { Successful = false, Error = "Username and password are invalid." });

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.UserName),
                new Claim("UserId", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResponse { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
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
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
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

            return Ok(new RegisterResponse { Status = "Success", Message = "User created successfully!" });

            //var roles = await _roleRepository.GetAllRole();

            //if (roles.Count() == 0)
            //{
            //    Role role = new Role()
            //    {
            //        Name = UserRoles.User,
            //        NormalizedName = UserRoles.User,
            //        Created_at = DateTime.Now,
            //        Updated_at = DateTime.Now
            //    };
            //    var roleCreate = await _roleRepository.CreateRole(role);
            //    if (roleCreate == null)
            //    {
            //        return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
            //        {
            //            Status = "Error",
            //            Message = "User creation failed! Add role failed!"
            //        });
            //    }
            //}
            //else
            //{
            //    foreach (var item in roles)
            //    {
            //        if (item.Name != UserRoles.User)
            //        {
            //            Role role = new Role()
            //            {
            //                Name = UserRoles.User,
            //                NormalizedName = UserRoles.User,
            //                Created_at = DateTime.Now,
            //                Updated_at = DateTime.Now
            //            };
            //            var roleCreate = await _roleRepository.CreateRole(role);
            //            if (roleCreate == null)
            //            {
            //                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
            //                {
            //                    Status = "Error",
            //                    Message = "User creation failed! Add role failed!"
            //                });
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}

            //var roleuser = await _userManager.GetRolesAsync(user);

            //if (roleuser.Count() == 0)
            //{
            //    await _userManager.AddToRoleAsync(user, UserRoles.User);
            //}
        }

        //[HttpPost]
        //[Route("register-admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUser regis)
        //{
        //    var userExists = await _userManager.FindByNameAsync(regis.UserName);
        //    if (userExists != null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
        //        {
        //            Status = "Error",
        //            Message = "User already exists!"
        //        });
        //    }

        //    User user = new User()
        //    {
        //        FirstName = regis.FirstName,
        //        LastName = regis.LastName,
        //        Email = regis.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = regis.UserName,
        //        NormalizedUserName = regis.UserName.ToUpper(),
        //        NormalizedEmail = regis.Email.ToUpper(),
        //        Created_at = DateTime.Now,
        //        Updated_at = DateTime.Now
        //    };

        //    user.PasswordHash = _passwordHasher.HashPassword(user, regis.PassWordHash);

        //    var result = await _userRepository.CreateUser(user);

        //    var roles = await _roleRepository.GetAllRole();

        //    if (roles == null)
        //    {
        //        Role role = new Role()
        //        {
        //            Name = UserRoles.Admin,
        //            NormalizedName = UserRoles.Admin,
        //            Created_at = DateTime.Now,
        //            Updated_at = DateTime.Now
        //        };
        //        var roleCreate = await _roleRepository.CreateRole(role);
        //        if (roleCreate == null)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
        //            {
        //                Status = "Error",
        //                Message = "User creation failed! Add role failed!"
        //            });
        //        }
        //    }
        //    else
        //    {
        //        foreach (var item in roles)
        //        {
        //            if (item.Name != UserRoles.Admin)
        //            {
        //                Role role = new Role()
        //                {
        //                    Name = UserRoles.Admin,
        //                    NormalizedName = UserRoles.Admin,
        //                    Created_at = DateTime.Now,
        //                    Updated_at = DateTime.Now
        //                };
        //                var roleCreate = await _roleRepository.CreateRole(role);
        //                if (roleCreate == null)
        //                {
        //                    return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
        //                    {
        //                        Status = "Error",
        //                        Message = "User creation failed! Add role failed!"
        //                    });
        //                }
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }

        //    if (result == null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse
        //        {
        //            Status = "Error",
        //            Message = "User creation failed! Please check user details and try again."
        //        });
        //    }

        //    var rolead = await _userManager.GetRolesAsync(user);

        //    if (rolead.Count() == 0)
        //    {
        //        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        //    }

        //    return Ok(new RegisterResponse { Status = "Success", Message = "User created successfully!" });
        //}
    }
}
