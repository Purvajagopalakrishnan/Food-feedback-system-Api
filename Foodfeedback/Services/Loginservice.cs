using Foodfeedback.DTO;
using Foodfeedback.Models;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Foodfeedback.Services
{
    public class Loginservice : ILoginService
    {
        /// <summary>
        /// checks if the given user exist or not
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public bool CheckIfUserExists([FromBody]UserDTO userDTO)
        {
            var entities = new FoodfeedbackDBContext();
            var loginresult = entities.Users.Where(x => x.Email == userDTO.Email && x.Password == userDTO.Password).Any();
            return loginresult;
        }
    }
}
