using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccessFlightBooking.Models
{
    public class BookingHistory
    {
        [Key]
        public string PNRNumber { get; set; }
        [ForeignKey("UserID")]
        public string UserID { get; set; }
        public string UserName { get; set; }                
        public List<Passenger> PassengerDetails { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string ClassType { get; set; }
        public DateTime Doj { get; set; }
        public string FlightNumber { get; set; }
        public string AppliedCoupon { get; set; }
    }      
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]                
        public string id { get; set; }    
        [JsonIgnore]
        public string BookingHistoryPNRNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }        
        public string OptForMeal { get; set; }
        public int SeatNo { get; set; }        
    }
}
