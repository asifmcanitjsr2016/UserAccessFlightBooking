using AdminAccessFlightBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAccessFlightBooking.AirlineRepositories
{
    public interface IAirlineRepository
    {
        
        bool AddFlight(FlightDetails flight);
        FlightDetails GetFlightDetails(string flightNumber);
        bool UpdateFlightDetails(string flightnum, FlightDetails flightNumber);
        bool DeleteFlight(string flightNumber);
    }
}
