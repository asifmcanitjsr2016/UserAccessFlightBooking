using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public List<Discount> Discounts { get; set; }
    }

    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string CouponCode { get; set; }
        public int Amount { get; set; }
        public string FlightDetailsFlightNumber { get; set; }
    }
}
