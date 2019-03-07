using Foodfeedback.DTO;
using Foodfeedback.Models;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodfeedback.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly FoodfeedbackDBContext _foodfeedbackDBContext;
        public RegistrationService(FoodfeedbackDBContext foodfeedbackDBContext)
        {
            _foodfeedbackDBContext = foodfeedbackDBContext;
        }
        /// <summary>
        /// Register the user details
        /// </summary>
        /// <param name="registrationDTO"></param>
        /// <returns>
        /// true if user register
        /// </returns>
        public bool RegisterUser([FromBody]RegistrationDTO registrationDTO)
        {
            var entities = new FoodfeedbackDBContext();
            var RegisteredUserDetails = new Users()
            {
                Email = registrationDTO.Email,
                Password = registrationDTO.Password,
                EmpId = registrationDTO.EmpId,
                Username = registrationDTO.Username,
            };
            entities.Users.Add(RegisteredUserDetails);
            entities.SaveChanges();
            return true;
        }
    }
}
