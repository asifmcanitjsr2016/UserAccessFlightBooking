using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAccessFlightBooking.Models;

namespace UserAccessFlightBooking.TicketBookingRepositories
{
    public interface ITicketBookingRepository
    {
        List<Flights> GetFlights(SearchFlight searchFlight);
        bool BookFlight(BookingHistory bookingHistory);        
        List<BookingHistory> TicketBookingHistory(string UserEmailID);
        Passengers BookedTicketDetails(string PNR);
        BookingHistory PrintTicket(string PNR);
        bool CancelTicket(string PNR);
    }
}
