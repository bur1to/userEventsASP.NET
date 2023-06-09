﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using userEventsASP.NET.Data;
using userEventsASP.NET.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace userEventsASP.NET.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        public LoginController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            User user = Authenticate(userLogin);

            if (user == null)
            {
                return NotFound("User not found");
            }

            user.Token = GenerateToken(user);

            return Ok(user);
        }

        private string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.FirstName),
                new Claim(ClaimTypes.Email,user.Email)
            };
            SecurityToken token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserLogin userLogin)
        {
            User currentUser = null;

            User email = _context.Users.FirstOrDefault(user => user.Email == userLogin.Email);

            if (email == null)
            {
                throw new Exception("Incorrect email");
            } 
            else
            {
                if (email.Password != userLogin.Password)
                {
                    throw new Exception("Incorrect password");
                } 
                else
                {
                    currentUser = email;
                }
            }

            return currentUser;
        }
    }
}
