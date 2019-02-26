using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Foodfeedback.DTO;
using Foodfeedback.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foodfeedback.Controllers
{
    [Route("api/login")]
    public class LoginController: Controller
    {
        [HttpPost]
        public bool GetUserdetails([FromBody] UserDTO user)
        {
            var entities = new FoodfeedbackDBContext();
            var result = entities.Users.Where(x => x.Email == user.Email && x.Password == user.Password).Any();
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