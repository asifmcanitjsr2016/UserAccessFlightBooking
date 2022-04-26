using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccessFlightBooking.DBContexts;
using UserAccessFlightBooking.Models;

namespace UserAccessFlightBooking.TicketBookingRepositories
{
    public class TicketBookingRepository : ITicketBookingRepository
    {
        private readonly TicketBookingContext _dbContext;        

        public TicketBookingRepository(TicketBookingContext dbcontext)
        //public TicketBookingRepository()

        {
            //    BookingHistory = new List<BookingHistory> {
            //         new BookingHistory()
            //         {

            //                      Doj=new DateTime(2022,04,22),
            //                      FlightNumber="ABC001",
            //                       FromPlace="Kolkata",
            //                        ToPlace="New Delhi",
            //                         PNRNumber ="1298767564",
            //                          PassengerDetls=new List<Passenger>
            //                          {
            //                              new Passenger()
            //                              {
            //                               Age=24,
            //                                ClassType="Business",
            //                                 Gender="Male",
            //                                  Name="Asif",
            //                                   OptForMeal="None",
            //                                    SeatNo=23
            //                              }
            //                          },


            //                   UserID="asif777hussain@gmail.com",
            //                    UserName="Asif Hussain"

            //         },
            //         new BookingHistory()
            //         {

            //                      Doj=new DateTime(2022,04,25),
            //                      FlightNumber="ABC001",
            //                       FromPlace="Kolkata",
            //                        ToPlace="New Delhi",
            //                         PNRNumber ="1298767565",
            //                          PassengerDetls=new List<Passenger>
            //                          {
            //                          new Passenger()
            //                          {
            //                               Age=30,
            //                                ClassType="Non Business",
            //                                 Gender="Male",
            //                                  Name="Aman",
            //                                   OptForMeal="None",
            //                                    SeatNo=72
            //                          }
            //                          },


            //                   UserID="asif777hussain@gmail.com",
            //                    UserName="Asif Hussain"

            //         }
            //    };

            //    flights = new List<FlightDetails> 
            //    {
            //        new FlightDetails
            //        {
            //            FlightNumber = "ABC001",
            //            Airline = "Air India",
            //            AirlineStatus = "Open",
            //            EndDateTime = new DateTime(2030, 1, 1),
            //            FromPlace = "Kolkata",
            //            ToPlace = "New Delhi",
            //            InstrumentUsed = "A320",
            //            Price = 5600,
            //            ScheduledDays = "Daily",
            //            StartDateTime = new DateTime(2022, 4, 12),
            //            TotalBusinessClassSeat = 20,
            //            TotalNonBusinessClassSeat = 80,
            //            Meal="Veg,Non-Veg,None",
            //            NoOfRows=25

            //        },
            //        new FlightDetails
            //        {
            //            FlightNumber = "ABC002",
            //            Airline = "Indigo",
            //            AirlineStatus = "Open",
            //            EndDateTime = new DateTime(2030, 1, 1),
            //            FromPlace = "New Delhi",
            //            ToPlace = "Kolkata",
            //            InstrumentUsed = "A320 neo",
            //            Price = 5600,
            //            ScheduledDays = "Daily",
            //            StartDateTime = new DateTime(2022, 4, 12),
            //            TotalBusinessClassSeat = 20,
            //            TotalNonBusinessClassSeat = 80,
            //            Meal="Veg,Non-Veg,None",
            //            NoOfRows=25

            //        },
            //        new FlightDetails
            //        {
            //            FlightNumber = "ABC003",
            //            Airline = "Air Asia",
            //            AirlineStatus = "Open",
            //            EndDateTime = new DateTime(2030, 1, 1),
            //            FromPlace = "New Delhi",
            //            ToPlace = "Mumbai",
            //            InstrumentUsed = "A321",
            //            Price = 4000,
            //            ScheduledDays = "Daily",
            //            StartDateTime = new DateTime(2022, 4, 12),
            //            TotalBusinessClassSeat = 20,
            //            TotalNonBusinessClassSeat = 80,
            //            Meal="Veg,None",
            //            NoOfRows=25

            //        }
            //        };



            _dbContext = dbcontext;
        }
        public BookingHistory BookedTicketDetails(string PNR)
        {
            try
            {
                var pass = _dbContext.BookingHistory.Include(x=>x.PassengerDetails).ToList();
                var pass1 = pass.Where(x => x.PassengerDetails.Any(y => y.BookingHistoryPNRNumber.Equals(PNR)));
                if (pass1.Count() > 0)
                {                    
                    return pass1.FirstOrDefault();
                }                
                return null;                
            }
            catch(Exception ex)
            {

                return null;
            }
        }
        
        public string GeneratePNR()
        {
            Random random = new Random(); 
            StringBuilder sb = new StringBuilder(); 
            for (int i = 0; i < 10; i++) 
            { 
                sb.Append(random.Next(0, 9).ToString()); 
            }
            return sb.ToString();

        }

        public bool BookFlight(BookingHistory bookingHistory)
        {
            try
            {
                string pnr = "";
                do
                {
                    pnr = GeneratePNR();

                } while (_dbContext.BookingHistory.Any(x => x.PNRNumber.Equals(pnr)));                

                bookingHistory.PNRNumber = pnr;                
                _dbContext.BookingHistory.Add(bookingHistory);

                Save();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CancelTicket(string PNR)
        {
            try
            {
                var data = _dbContext.BookingHistory.FirstOrDefault(x => x.PNRNumber.Equals(PNR));
                if (data!=null)
                {
                    _dbContext.BookingHistory.Remove(data);
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

        public List<Flights> AllFlightsWithAvailablility(SearchFlight searchFlight, List<FlightDetails> allFlights)
        {
            List<Flights> Lflts = new List<Flights>();
            var allBookedFlight = _dbContext.BookingHistory.Where(x => x.Doj == Convert.ToDateTime(searchFlight.date)).ToList();
            int totalAvailability;
            foreach (var flight in allFlights)
            {

                var bookedFlight = allBookedFlight.Where(x => x.FlightNumber.ToLower().Equals(flight.FlightNumber.ToLower())).Count();
                if (searchFlight.classtype.ToLower().Equals("business"))
                {
                    totalAvailability = flight.TotalBusinessClassSeat - bookedFlight;
                }
                else
                {
                    totalAvailability = flight.TotalNonBusinessClassSeat - bookedFlight;
                }
                Lflts.Add(new Flights()
                {
                    FlightName = flight.Airline,
                    FlightNumber = flight.FlightNumber,
                    FromPlace = searchFlight.fromplace,
                    ToPlace = searchFlight.toplace,
                    JourneyDate = Convert.ToDateTime(searchFlight.date),
                    Price = flight.Price,
                    TotalAvaiability = totalAvailability,
                    Discounts=flight.Discounts
                });
            }
            return Lflts;
        }

        public List<Flights> GetFlights(SearchFlight searchFlight)
        {
            
            try
            {
                if(searchFlight.way.ToLower().Equals("one way"))
                {
                    var allFlights = _dbContext.FlightDetails.Include(y => y.Discounts).Where(
                    x => x.AirlineStatus.ToLower().Equals("open")
                    && x.FromPlace.ToLower().Equals(searchFlight.fromplace.ToLower())
                    && x.ToPlace.ToLower().Equals(searchFlight.toplace.ToLower())
                    && x.ScheduledDays.Equals("Daily") || x.ScheduledDays.Contains(Convert.ToDateTime(searchFlight.date).ToString("ddd"))).ToList();

                    return AllFlightsWithAvailablility(searchFlight, allFlights);
                    
                }
                else
                {
                    var list1 = _dbContext.FlightDetails.Include(y=>y.Discounts).Where(
                    x => x.AirlineStatus.ToLower().Equals("open")
                    && x.FromPlace.ToLower().Equals(searchFlight.fromplace.ToLower())
                    && x.ToPlace.ToLower().Equals(searchFlight.toplace.ToLower())
                    && x.ScheduledDays.Equals("Daily") || x.ScheduledDays.Contains(Convert.ToDateTime(searchFlight.date).ToString("ddd"))).ToList();

                    var list2 = _dbContext.FlightDetails.Include(y=>y.Discounts).Where(
                    x => x.AirlineStatus.ToLower().Equals("open")
                    && x.FromPlace.ToLower().Equals(searchFlight.toplace.ToLower())
                    && x.ToPlace.ToLower().Equals(searchFlight.fromplace.ToLower())
                    && x.ScheduledDays.Equals("Daily") || x.ScheduledDays.Contains(Convert.ToDateTime(searchFlight.returndate).ToString("ddd"))).ToList();

                    if (list1 != null)
                    {
                        list1.AddRange(list2);
                        return AllFlightsWithAvailablility(searchFlight, list1);
                    }
                    else if (list2 != null)
                    {
                        list2.AddRange(list1);
                        return AllFlightsWithAvailablility(searchFlight, list2);
                    }
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public BookingHistory PrintTicket(string PNR)
        {
            try
            {
                return _dbContext.BookingHistory.Include(x=>x.PassengerDetails).Where(y => y.PNRNumber.ToLower().Equals(PNR))?.FirstOrDefault();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<BookingHistory> TicketBookingHistory(string UserEmailID)
        {
            try
            {
                return _dbContext.BookingHistory.Include(x=>x.PassengerDetails).Where(y => y.UserID.ToLower().Equals(UserEmailID))?.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }        
    }
}
