using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccessFlightBooking.Models
{
    public class SearchFlight
    {
        public string date { get; set; }
        public string returndate { get; set; }
        public string fromplace { get; set; }
        public string toplace { get; set; }
        public string classtype { get; set; }
        public string way { get; set; }
    }
}
