using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreManagement.Models;
using StoreManagement.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : Controller
    {
        public IConfiguration _configuration;
        private IUserRepository _userRepository;
        public LoginsController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        [HttpPost]
        public IActionResult Login(User modelUser)
        {
            if (modelUser!=null && modelUser.Username !=null && modelUser.Password!=null)
            {
                var user = _userRepository.GetUser(modelUser.Username, modelUser.Password);
                if (user!=null)
                {
                    var claims = new[]
                    {
                        new Claim("User_ID",user.User_ID.ToString()),
                        new Claim("Username",user.Username),
                        new Claim("Password",user.Password),
                        new Claim("Role",user.Role),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Auduence"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    return Json(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                    return BadRequest("Invalid Credentials");
            }
            else
                return BadRequest();
        }
        [HttpGet("{username}")]
        public IActionResult GetByUserName(string username)
        {
            var user = _userRepository.getByUsername(username);
            return Ok(user);
        }
        [HttpGet]
        public IActionResult GetAllUer()
        {
            var listUser = _userRepository.getUserAll();
            return Ok(listUser);
        }
    }
}
