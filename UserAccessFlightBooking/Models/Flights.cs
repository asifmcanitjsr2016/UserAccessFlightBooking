using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccessFlightBooking.Models
{
    public class Flights
    {
        public string FromPlace { get; set; } 
        public string ToPlace { get; set; } 
        public string FlightNumber { get; set; } 
        public string FlightName { get; set; } 
        public int Price { get; set; } 
        public DateTime JourneyDate { get; set; } 
        public int TotalAvaiability { get; set; }
        public List<Discount> Discounts { get; set; }
    }    
}
