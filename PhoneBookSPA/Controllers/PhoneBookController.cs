using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IPhoneBookService _phoneBookService;
        private readonly ILogger<PhoneBookController> _logger;

        public PhoneBookController(IPhoneBookService phoneBookService,
                                    ILogger<PhoneBookController> logger)
        {
            _phoneBookService = phoneBookService;
            _logger = logger;

        }

        [HttpGet]
        public ActionResult<PhoneBook> Get()
        {
            PhoneBook phoneBookEntity = new PhoneBook();
            var response = _phoneBookService.GetPhoneBookDetails();

            if(response == null)
            {
                return StatusCode(404);
            }
            phoneBookEntity = response.Result;
            return StatusCode(200,phoneBookEntity);
        }

    }
}
