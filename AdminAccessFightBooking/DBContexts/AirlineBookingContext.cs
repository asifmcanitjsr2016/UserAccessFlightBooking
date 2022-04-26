using System;
using AdminAccessFlightBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminAccessFlightBooking.DBContexts
{
    public class AirlineBookingContext : DbContext
    {
        public AirlineBookingContext(DbContextOptions<AirlineBookingContext> options) : base(options)
        {
        }        
        public DbSet<FlightDetails> FlightDetails { get; set; }                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightDetails>();                                    
        }
    }
    
}
