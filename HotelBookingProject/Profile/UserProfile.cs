using System;
using AutoMapper;
using HotelBooking.Model;
using HotelBookingProject.Model;

namespace HotelBookingProject
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{

			CreateMap<User, UserDTO>();
		}
	}
}

