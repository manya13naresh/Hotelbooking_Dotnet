using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Model
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Place { get; set; } = null!;

    }
}

