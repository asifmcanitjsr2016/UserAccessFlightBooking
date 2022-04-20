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
        public DbSet<UserLoginDetails> UserLoginDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightDetails>().HasData(
                new FlightDetails
                {
                    FlightNumber = "ABC001",
                    Airline = "Air India",
                    AirlineStatus = "Open",
                    EndDateTime = new DateTime(2030, 1, 1),
                    FromPlace = "Kolkata",
                    ToPlace = "New Delhi",
                    InstrumentUsed = "A320",
                    Price = 5600,
                    ScheduledDays = "Daily",
                    StartDateTime = new DateTime(2022, 4, 12),
                    TotalBusinessClassSeat = 20,
                    TotalNonBusinessClassSeat = 80

                },
                new FlightDetails
                {
                    FlightNumber = "ABC002",
                    Airline = "Indigo",
                    AirlineStatus = "Open",
                    EndDateTime = new DateTime(2030, 1, 1),
                    FromPlace = "New Delhi",
                    ToPlace = "Kolkata",
                    InstrumentUsed = "A320 neo",
                    Price = 5600,
                    ScheduledDays = "Daily",
                    StartDateTime = new DateTime(2022, 4, 12),
                    TotalBusinessClassSeat = 20,
                    TotalNonBusinessClassSeat = 80

                },
                new FlightDetails
                {
                    FlightNumber = "ABC003",
                    Airline = "Air Asia",
                    AirlineStatus = "Open",
                    EndDateTime = new DateTime(2030, 1, 1),
                    FromPlace = "New Delhi",
                    ToPlace = "Mumbai",
                    InstrumentUsed = "A321",
                    Price = 4000,
                    ScheduledDays = "Daily",
                    StartDateTime = new DateTime(2022, 4, 12),
                    TotalBusinessClassSeat = 20,
                    TotalNonBusinessClassSeat = 80

                }
            );
            modelBuilder.Entity<UserLoginDetails>().HasData(
                new UserLoginDetails
                {
                    UserType="Admin",
                    UserID = "asif123@gmail.com",
                    Name = "Asif Hussain",
                    Age = 30,
                    Gender = "Male",
                    Password = "Asif@123Hussain",
                    AccountCreated = new DateTime(2022, 4, 12)                     
                },
                new UserLoginDetails
                {
                    UserType = "User",
                    UserID = "arif123@gmail.com",
                    Name = "Arif Hussain",
                    Age = 25,
                    Gender = "Male",
                    Password = "Arif@123Hussain",
                    AccountCreated = new DateTime(2022, 4, 12)
                }
            );
        }
    }
    
}
