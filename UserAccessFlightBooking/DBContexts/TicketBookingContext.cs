using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserAccessFlightBooking.Models;

namespace UserAccessFlightBooking.DBContexts
{
    public class TicketBookingContext : DbContext
    {
        public TicketBookingContext(DbContextOptions<TicketBookingContext> options) : base(options)
        {
        }
        public DbSet<BookingHistory> BookingHistory { get; set; }
        public DbSet<FlightDetails> FlightDetails { get; set; }                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                        
            modelBuilder.Entity<BookingHistory>();            
        }
    }
    
}
