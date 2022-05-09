using AdminAccessFlightBooking.AirlineRepositories;
using AdminAccessFlightBooking.DBContexts;
using AdminAccessFlightBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminAccessFlightBooking.AirlineRepositories
{
    public class AirlineRepository : IAirlineRepository
    {

        //private List<FlightDetails> flights;        
        private readonly AirlineBookingContext _dbContext;

        public AirlineRepository(AirlineBookingContext dbcontext)
        //public AirlineRepository()

        {            

            //flights = new List<FlightDetails>
            //{
            //    new FlightDetails
            //    {
            //        FlightNumber = "ABC001",
            //        Airline = "Air India",
            //        AirlineStatus = "Open",
            //        EndDateTime = new DateTime(2030, 1, 1),
            //        FromPlace = "Kolkata",
            //        ToPlace = "New Delhi",
            //        InstrumentUsed = "A320",
            //        Price = 5600,
            //        ScheduledDays = "Daily",
            //        StartDateTime = new DateTime(2022, 4, 12),
            //        TotalBusinessClassSeat = 20,
            //        TotalNonBusinessClassSeat = 80,
            //        Meal="Veg,Non-Veg,None",
            //        NoOfRows=25

            //    },
            //    new FlightDetails
            //    {
            //        FlightNumber = "ABC002",
            //        Airline = "Indigo",
            //        AirlineStatus = "Open",
            //        EndDateTime = new DateTime(2030, 1, 1),
            //        FromPlace = "New Delhi",
            //        ToPlace = "Kolkata",
            //        InstrumentUsed = "A320 neo",
            //        Price = 5600,
            //        ScheduledDays = "Daily",
            //        StartDateTime = new DateTime(2022, 4, 12),
            //        TotalBusinessClassSeat = 20,
            //        TotalNonBusinessClassSeat = 80,
            //        Meal="Veg,Non-Veg,None",
            //        NoOfRows=25

            //    },
            //    new FlightDetails
            //    {
            //        FlightNumber = "ABC003",
            //        Airline = "Air Asia",
            //        AirlineStatus = "Open",
            //        EndDateTime = new DateTime(2030, 1, 1),
            //        FromPlace = "New Delhi",
            //        ToPlace = "Mumbai",
            //        InstrumentUsed = "A321",
            //        Price = 4000,
            //        ScheduledDays = "Daily",
            //        StartDateTime = new DateTime(2022, 4, 12),
            //        TotalBusinessClassSeat = 20,
            //        TotalNonBusinessClassSeat = 80,
            //        Meal="Veg,None",
            //        NoOfRows=25

            //    }
            //    };



            _dbContext = dbcontext;
        }        
        public bool AddFlight(FlightDetails flight)
        {
            try
            {
                
                if (!_dbContext.FlightDetails.Any(x => x.FlightNumber.ToLower().Equals(flight.FlightNumber.ToLower())))
                {
                    _dbContext.FlightDetails.Add(flight);
                    Save();
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
                return _dbContext.FlightDetails.Include(x => x.Discounts).FirstOrDefault(y => y.FlightNumber.ToLower().Equals(flightNumber.ToLower()));
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<FlightDetails> GetFlightDetails()
        {
            try
            {
                return _dbContext.FlightDetails.Include(x => x.Discounts).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UpdateFlightDetails(string flightnum, FlightDetails flightDetails)
        {
            try
            {
                var flight = _dbContext.FlightDetails.AsNoTracking().Where(x => x.FlightNumber.ToLower().Equals(flightnum.ToLower())).Include(y => y.Discounts).AsNoTracking().FirstOrDefault();
                flight = flightDetails;
                _dbContext.Entry(flight).State = EntityState.Modified;
                if (flight.Discounts != null)
                {
                    foreach (var flit in flight.Discounts)
                    {
                        if (flit.Id != null)
                            _dbContext.Entry(flit).State = EntityState.Modified;
                        else
                            _dbContext.Entry(flit).State = EntityState.Added;
                    }
                }                
                Save();
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
                var data = _dbContext.FlightDetails.Find(flightNumber);
                if (data != null)
                {
                    _dbContext.FlightDetails.Remove(data);
                    Save();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
