using AdminAccessFlightBooking.AirlineRepositories;
using AdminAccessFlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminAccessFlightBooking.AirlineRepositories
{
    public class AirlineRepository : IAirlineRepository
    {
        //private readonly TicketBookingContext _dbContext;
        private List<FlightDetails> flights;        

        //public TicketBookingRepository(TicketBookingContext dbcontext)
        public AirlineRepository()

        {            

            flights = new List<FlightDetails>
            {
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
                    TotalNonBusinessClassSeat = 80,
                    Meal="Veg,Non-Veg,None",
                    NoOfRows=25

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
                    TotalNonBusinessClassSeat = 80,
                    Meal="Veg,Non-Veg,None",
                    NoOfRows=25

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
                    TotalNonBusinessClassSeat = 80,
                    Meal="Veg,None",
                    NoOfRows=25

                }
                };



            //_dbContext = dbcontext;
        }        
        public bool AddFlight(FlightDetails flight)
        {
            try
            {
                if (!flights.Any(x => x.FlightNumber.ToLower().Equals(flight.FlightNumber.ToLower())))
                {
                    flights.Add(flight);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public FlightDetails GetFlightDetails(string flightNumber)
        {
            try
            {
                return flights.Find(x => x.FlightNumber.ToLower().Equals(flightNumber.ToLower()));
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool UpdateFlightDetails(string flightnum, FlightDetails flightDetails)
        {
            try
            {                
                var flight = flights.Find(x => x.FlightNumber.ToLower().Equals(flightnum.ToLower()));                
                
                flights.Remove(flight);                
                flights.Add(flightDetails);
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteFlight(string flightNumber)
        {
            try
            {
                if(flights.RemoveAll(x => x.FlightNumber.ToLower().Equals(flightNumber.ToLower())) > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }        
    }
}
