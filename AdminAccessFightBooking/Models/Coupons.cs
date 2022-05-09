using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAccessFlightBooking.Models
{
    public class Coupons
    {
        [Key]
        public string code { get; set; }
        public string amount { get; set; }
    }
}
