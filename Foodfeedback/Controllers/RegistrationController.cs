using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodfeedback.DTO;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foodfeedback.Controllers
{
    [Route("api/registration")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        [HttpPost]
        /// <summary>
        /// call the service and register the user details
        /// </summary>
        public IActionResult RegisterUserDetails([FromBody]RegistrationDTO registrationDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _registrationService.RegisterUser(registrationDTO);
                    if (result == true)
                    {
                        return Ok(result);
                    }
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
            
        }
    }
}