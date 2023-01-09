using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using BCrypt.Net;
using HotelBooking.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using bcrypt = BCrypt.Net.BCrypt;

namespace HotelBookingProject.Service
{
	public class LoginService : ILogin
	{
        private readonly HotelBookingDBContext _context;
        private readonly IConfiguration _configuration;
        public LoginService(HotelBookingDBContext context,IConfiguration configuration)
		{
			_context = context;
            _configuration = configuration;
		
		}
		[HttpPost]
        public string Login([FromBody] Login user)
        {
            Console.WriteLine(user.Email);
            
            var checkUser =  _context.Users.FirstOrDefault(x => x.Email == user.Email);
            Console.WriteLine();
            Console.WriteLine(checkUser);
            if(checkUser!= null)
            {
                if (bcrypt.Verify(user.Password, checkUser.Password))
                {
                    var token = generateToken(checkUser);
                    return token;
                }

                else
                {
                    return "Incorrect Password";
                }

            
            }
            else
            {
                return "User not found";
            }

        }


        public string generateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,user.Role.GetValueOrDefault(true).ToString()),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

    }


}

