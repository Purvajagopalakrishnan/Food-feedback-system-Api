using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Foodfeedback.DTO;
using Foodfeedback.Models;
using Foodfeedback.Services;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foodfeedback.Controllers
{
    [Route("api/login")]
    public class LoginController
    {
        private ILogin iLogin = new Loginservice();
        [HttpPost]
        public bool GetUserdetails([FromBody]UserDTO user)
        {
           var result = iLogin.Userdetails(user);
           return result;
        }
        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}