using System;
using BCrypt.Net;
using HotelBooking.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bcrypt = BCrypt.Net.BCrypt;



namespace HotelBookingProject.Service
{
    
    public class RegisterService:IRegister
	{
        private readonly HotelBookingDBContext _context;

        public RegisterService(HotelBookingDBContext context)
        {
            _context = context;

        }
  
        public string Register([FromBody] User user)
        {
            var checkUser = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (checkUser == null)
            {
                Console.WriteLine("1111" + checkUser);
                user.Password = bcrypt.HashPassword(user.Password, 12);
                _context.Users.Add(user);
                _context.SaveChanges();
                return ("User Created Successfully");
            }
            else
            {
                Console.WriteLine("1111"+checkUser);
                return ("User already exsits");
            }
        }
    }
}


