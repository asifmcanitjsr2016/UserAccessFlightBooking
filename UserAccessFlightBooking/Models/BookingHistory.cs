using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccessFlightBooking.Models
{
    public class BookingHistory
    {
        public UserDetails User { get; set; }
        public Passengers PassengerDetails { get; set; }        
    }
    public class Passengers
    {
        [Key]
        public string PNRNumber { get; set; }
        public List<Passenger> PassengerDetls { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime Doj { get; set; }
        public string FlightNumber { get; set; }

    }
}
