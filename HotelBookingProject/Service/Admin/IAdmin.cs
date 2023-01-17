using System;
using HotelBooking.Model;
using HotelBookingProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingProject.Service
{
	public interface IAdmin
	{
        
        public Task<List<User>> getUsers();
        public Task<User> getUsersByUsername(UserDTO user);
        public Task<User> getUsersByEmail(UserDTO user);
        public string addLocation(Location location);

    }
}

