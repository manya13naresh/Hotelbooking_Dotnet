using System;
using HotelBooking.Model;
using System.Collections.Generic;
using HotelBookingProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HotelBookingProject.ErrorHandling;

namespace HotelBookingProject.Service
{
	public class AdminService : IAdmin
	{
        private readonly HotelBookingDBContext _context;
        private readonly IMapper _mapper;
        public AdminService(HotelBookingDBContext context,IMapper mapper)
		{
            _context = context;
            _mapper = mapper;
        }
        //public  Task<IActionResult> getUsers()
        //{
        //    var checkUsers = _context.Users.Select(x => new { Email = x.Email, Username = x.Username }).ToList();

        //    return checkUsers;


        //}
        public async Task<List<User>> getUsers()
        {

            if (_context.Users == null)
            {
                return null;
            }
            var checkUsers = await _context.Users.ToListAsync();
            return checkUsers;
        }


        public async Task<User> getUsersByUsername([FromBody] UserDTO user)
        {
            var checkUsers = _context.Users.FirstOrDefault(x => x.Username == user.Username);
            if (checkUsers == null)
            {
                return null;
            }

            return checkUsers;
        }
        //public ActionResult getUsersByEmail([FromBody] UserDTO user)
        //{


        //    var checkUsers = _context.Users.FirstOrDefault(x => x.Email == user.Email);
        //    if (checkUsers == null)
        //    {
        //        return BadRequest("User not found");
        //    }


        //    return Ok(checkUsers);
        //}
        public async Task<User> getUsersByEmail([FromBody] UserDTO user)
        {
            var checkUsers = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (checkUsers == null)
            {
                return null;
            }

            return checkUsers;
        }
        public string addLocation([FromBody] Location location)
        {
            var checkLocation = _context.Locations.FirstOrDefault(x => x.Place == location.Place);
            Console.Write(checkLocation);
            if (checkLocation == null)
            {


                _context.Locations.Add(location);
                _context.SaveChanges();
                return ("Location Added Successfully");
            }
            else
            {

                return ("Location already exsits");
            }

        }

    }
}

