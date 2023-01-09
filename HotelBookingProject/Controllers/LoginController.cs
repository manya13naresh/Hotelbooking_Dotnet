using System;
using HotelBooking.Model;
using HotelBookingProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingProject.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class LoginController: ControllerBase
    {
		private readonly ILogin _login;

        public LoginController(ILogin login)
		{
			_login = login;
			
		}
		[HttpPost]
        public string Login([FromBody] Login login)
		{
			return _login.Login(login);
		}

    }
}

