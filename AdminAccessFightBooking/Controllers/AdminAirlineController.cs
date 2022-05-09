using AdminAccessFlightBooking.AirlineRepositories;
using AdminAccessFlightBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminAccessFightBooking.Controllers
{
    [Route("api/v1.0/flight")]
    [ApiController]
    public class AdminAirlineController : ControllerBase
    {
        private readonly IAirlineRepository _airlineRepository;

        public AdminAirlineController(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }
        //
        // GET: api/<AdminAirlineController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminAirlineController>/5
        [HttpGet("airline/getFlight")]
        public FlightDetails Get(string flightnumber)
        {
            return _airlineRepository.GetFlightDetails(flightnumber);
        }

        [HttpGet("airline")]
        public List<FlightDetails> GetFlights()
        {
            return _airlineRepository.GetFlightDetails();
        }

        // POST api/<AdminAirlineController>
        [HttpPost("airline/inventory/add")]
        public bool Post([FromBody] FlightDetails value)
        {
            return _airlineRepository.AddFlight(value);
        }

        // PUT api/<AdminAirlineController>/5
        [HttpPut("airline/inventory/update")]
        public bool Put(string flightnumber, [FromBody] FlightDetails value)
        {
            return _airlineRepository.UpdateFlightDetails(flightnumber, value);
        }

        // DELETE api/<AdminAirlineController>/5
        [HttpDelete("airline/inventory/delete")]
        public bool Delete(string flightNumber)
        {
            return _airlineRepository.DeleteFlight(flightNumber);
        }
    }
}
