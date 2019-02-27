using Foodfeedback.DTO;
using Foodfeedback.Models;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Foodfeedback.Services
{
    public class Loginservice : ILogin
    {
        bool ILogin.Userdetails([FromBody]UserDTO user)
        {
            var entities = new FoodfeedbackDBContext();
            var result = entities.Users.Where(x => x.Email == user.Email && x.Password == user.Password).Any();
            return result;
        }
    }
}
