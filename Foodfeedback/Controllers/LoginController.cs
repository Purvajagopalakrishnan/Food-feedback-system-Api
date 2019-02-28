using Foodfeedback.DTO;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foodfeedback.Controllers
{
    [Route("api/login")]
    public class LoginController
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public bool GetUserdetails([FromBody]UserDTO userDTO)
        {
           var result = _loginService.Userdetails(userDTO);
           return result;
        }
    }
}