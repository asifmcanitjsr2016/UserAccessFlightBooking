using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccessFlightBooking.Models
{
    public class PassengerDetails
    {
        public UserDetails User { get; set; }        
        public int TotalSeat { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime Doj { get; set; }
        public string FlightNumber { get; set; }
        public List<Passenger> PassengerDetls { get; set; }
    }

    public class UserDetails
    {
        public string UserEmailID { get; set; }
        public string UserName { get; set; }
    }
    public class Passenger
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ClassType { get; set; }
        public string OptForMeal { get; set; }        
        public int SeatNo { get; set; }        
    }
}
