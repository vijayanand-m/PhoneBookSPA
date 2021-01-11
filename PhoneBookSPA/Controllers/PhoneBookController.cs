using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookSPA.Entities;
using PhoneBookSPA.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookSPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private IPhoneBookServices _phoneBookServices;

        public PhoneBookController(IPhoneBookServices phoneBookServices)
        {
            _phoneBookServices = phoneBookServices;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            PhoneBook phoneBookEntity = new PhoneBook();
            var response = _phoneBookServices.GetPhoneBookDetails();

            if(response.Result == null)
            {
                return NotFound();
            }
            phoneBookEntity = response.Result;
            return Ok(phoneBookEntity);
        }

    }
}
