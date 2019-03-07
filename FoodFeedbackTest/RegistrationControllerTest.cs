using Foodfeedback.Controllers;
using Foodfeedback.DTO;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace FoodFeedbackTest
{
    public class RegistrationControllerTest
    {
        [Fact]
        public void ShouldRegisterValidUser()
        {
            var mockRegistrationService = new Mock<IRegistrationService>();
            mockRegistrationService.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == "john89@cesltd.com" && x.Password == "welcome" && x.EmpId == "CES/108" && x.Username == "John"))).Returns(true);
            var UserRegistrationDetails = new RegistrationController(mockRegistrationService.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome",
                EmpId = "CES/108",
                Username = "John"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Fact]
        public void RegisterUser_IfFieldIsEmpty_ReturnsFalse()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.IsAny<RegistrationDTO>())).Returns(false);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "",
                Password = "",
                EmpId = "",
                Username = ""
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
    }
}
