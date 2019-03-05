using Foodfeedback.DTO;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Foodfeedback.Controllers
{
    [Route("api/login")]
    /// <summary>
    /// provides login information
    /// </summary>
    public class LoginController:Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        /// <summary>
        /// call the service and check if the user exists
        /// </summary>
        public IActionResult GetUserdetails([FromBody]UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _loginService.CheckIfUserExists(userDTO);
                    if (result == true)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return Ok(result);
                    }
                }
                catch(Exception)
                {
                   return StatusCode(500);
                }
            }
            return BadRequest();
        }
    }
}