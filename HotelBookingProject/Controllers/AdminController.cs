using System;
using System.Collections.Generic;
using System.Data;
using AutoMapper;
using BCrypt.Net;
using HotelBooking.Model;
using HotelBookingProject.Model;
using HotelBookingProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingProject.Controllers
{
	[ApiController]
	public class AdminController : ControllerBase
    {
		private readonly IAdmin _admin;
        private readonly IMapper _mapper;
        public AdminController(IAdmin admin,IMapper mapper)
		{
			_admin = admin;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("getusers"),Authorize(Roles = "False")]
        public async Task<IActionResult> getUsers()
        {

            List<User> checkUsers = await _admin.getUsers();
            if (checkUsers.Count == null)
            {
                return NotFound("No Users found");
            }
            else
            {
                return Ok(_mapper.Map<IEnumerable<UserDTO>>(checkUsers));
            }
        }
        [HttpPost]
        [Route("getusersbyUsername"), Authorize(Roles = "False")]
        public async Task<IActionResult> getUsersByUsername([FromBody] UserDTO user)
        {

            var checkUsers = await _admin.getUsersByUsername(user);
            if (checkUsers == null)
            {
                return NotFound("No User found");
            }
            else
            {
                return Ok(_mapper.Map<UserDTO>(checkUsers));
            }
        }
        [HttpPost]
        [Route("getusersbyEmail"), Authorize(Roles = "False")]
        public async Task<IActionResult> getUsersByEmail([FromBody] UserDTO user)
        {

            var checkUsers = await _admin.getUsersByEmail(user);
            if (checkUsers == null)
            {
                return NotFound("No User found");
            }
            else
            {
                return Ok(_mapper.Map<UserDTO>(checkUsers));
            }
        }
        [HttpPost]
        [Route("addLocation"), Authorize(Roles = "False")]
        public string addLocation([FromBody] Location location)
        {
            return _admin.addLocation(location);
        }
    }

}


