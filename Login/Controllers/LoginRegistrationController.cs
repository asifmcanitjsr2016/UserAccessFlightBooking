using Login.LoginRepository;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    [Route("api/v1.0/flight")]
    [ApiController]
    public class LoginRegistrationController : ControllerBase
    {
        private readonly IRegisterLoginRepository _registerLoginRepository;

        public LoginRegistrationController(IRegisterLoginRepository registerLoginRepository)
        {
            _registerLoginRepository = registerLoginRepository;
        }
        // GET: api/<LoginRegistrationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginRegistrationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginRegistrationController>
        [HttpPost("admin/login")]
        public object Post([FromBody] UserLogin value)
        {
            return _registerLoginRepository.Login(value.username, value.password);
        }

        [HttpPost("airline/register")]
        public bool Post([FromBody] UserLoginDetails value)
        {
            return _registerLoginRepository.Registration(value);
        }

        // PUT api/<LoginRegistrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginRegistrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
