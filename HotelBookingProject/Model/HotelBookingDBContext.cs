
using System;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Model
{
    public class HotelBookingDBContext : DbContext
    {
        public HotelBookingDBContext(DbContextOptions<HotelBookingDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
    }

}
