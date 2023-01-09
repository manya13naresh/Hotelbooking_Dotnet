using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Model;
using HotelBookingProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bcrypt = BCrypt.Net.BCrypt;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelBookingProject.Controllers
{
    

    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {


        private readonly IRegister _register;

        public RegisterController(IRegister register)
        {
            _register = register;

        }
            [HttpPost]

            public string Register(User user)
           {
            Console.WriteLine("aaa");
            Console.WriteLine(user);
            return _register.Register(user);
           }
    }
}

