using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAccessFlightBooking.Models
{
    public class FlightDetails
    {
        [Key]
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public int Price { get; set; }
        public string ToPlace { get; set; }
        public string FromPlace { get; set; }
        public string ScheduledDays { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string InstrumentUsed { get; set; }
        public int TotalBusinessClassSeat { get; set; }
        public int TotalNonBusinessClassSeat { get; set; }
        public string AirlineStatus { get; set; }
        public int NoOfRows { get; set; }
        public string Meal { get; set; }
    }
}
