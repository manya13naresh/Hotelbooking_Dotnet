using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class Login
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;


    }
}
