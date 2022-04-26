using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAccessFlightBooking.Models;
using UserAccessFlightBooking.TicketBookingRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAccessFlightBooking.Controllers
{
    [Route("api/v1.0/flight")]
    [ApiController]
    public class FlightBookingController : ControllerBase
    {
        private readonly ITicketBookingRepository _ticketBookingRepository;
        public FlightBookingController(ITicketBookingRepository ticketBookingRepository)
        {
            _ticketBookingRepository = ticketBookingRepository;
        }
        // GET: api/<FlightBookingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"value1","value2" };
        }

        [HttpPost("search")]
        public IEnumerable<Flights> Post([FromBody] SearchFlight flight)
        {
            return _ticketBookingRepository.GetFlights(flight);
        }

        // GET api/<FlightBookingController>/5
        [HttpGet("ticket")]
        public BookingHistory Get(string pnr)
        {
            return _ticketBookingRepository.BookedTicketDetails(pnr);
        }

        [HttpGet("booking/history")]
        public List<BookingHistory> BookingHistory(string emailID)
        {
            return _ticketBookingRepository.TicketBookingHistory(emailID);
        }

        // POST api/<FlightBookingController>
        [HttpPost("booking")]
        public bool Post([FromBody] BookingHistory value)
        {
            return _ticketBookingRepository.BookFlight(value);
        }        

        // PUT api/<FlightBookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlightBookingController>/5
        [HttpDelete("booking/cancel")]
        public bool Delete(string pnr)
        {
           return _ticketBookingRepository.CancelTicket(pnr);
        }
    }
}
