using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccessFlightBooking.Models
{
    public class UserLoginDetails
    {
        [Key]
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime AccountCreated { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
