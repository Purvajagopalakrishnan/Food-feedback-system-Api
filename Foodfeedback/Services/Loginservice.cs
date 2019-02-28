using Foodfeedback.DTO;
using Foodfeedback.Models;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Foodfeedback.Services
{
    public class Loginservice : ILoginService
    {
        bool ILoginService.Userdetails([FromBody]UserDTO userDTO)
        {
            var entities = new FoodfeedbackDBContext();
            var loginresult = entities.Users.Where(x => x.Email == userDTO.Email && x.Password == userDTO.Password).Any();
            return loginresult;
        }
    }
}
