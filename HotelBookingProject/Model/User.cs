using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? Role { get; set; } = true;


    }
}

