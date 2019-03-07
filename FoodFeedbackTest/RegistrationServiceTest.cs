using Foodfeedback.Controllers;
using Foodfeedback.DTO;
using Foodfeedback.Models;
using Foodfeedback.Services;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FoodFeedbackTest
{
    public class RegistrationServiceTest
    {
        [Fact]
        public void RegisterUser_IfValid_ReturnsTrue()
        {
            var mockSet = new Mock<DbSet<Users>>();
            var mockContext = new Mock<FoodfeedbackDBContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            var service = new RegistrationService(mockContext.Object);
            var response = service.RegisterUser(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome",
                Username = "John",
                EmpId = "CES/100"
            });
            Assert.True(response);
        }
        [Fact]
        public void RegisterUser_IfUsernameIsEmpty_ReturnsFalse()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == "john89@cesltd.com" && x.Password == "test" && x.EmpId == "CES/100" && x.Username == string.Empty))).Returns(false);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = "test",
                EmpId = "CES/100",
                Username = ""
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
        [Fact]
        public void RegisterUser_IfEmailIsEmpty_ReturnsFalse()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == string.Empty && x.Password == "test" && x.EmpId == "CES/100" && x.Username == "john"))).Returns(false);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "",
                Password = "test",
                EmpId = "CES/100",
                Username = "john"
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
        [Fact]
        public void RegisterUser_IfPasswordIsEmpty_ReturnsFalse()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == "john89@cesltd.com" && x.Password == string.Empty && x.EmpId == "CES/100" && x.Username == "john"))).Returns(false);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = string.Empty,
                EmpId = "CES/100",
                Username = "john"
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
        [Fact]
        public void RegisterUser_IfEmployeeIDIsEmpty_ReturnsFalse()
        {
            var mockLoginervice = new Mock<IRegistrationService>();
            mockLoginervice.Setup(details => details.RegisterUser(It.Is<RegistrationDTO>(x => x.Email == "john89@cesltd.com" && x.Password == "welcome" && x.EmpId == string.Empty && x.Username == "john"))).Returns(false);
            var UserRegistrationDetails = new RegistrationController(mockLoginervice.Object);
            var response = UserRegistrationDetails.RegisterUserDetails(new RegistrationDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome",
                EmpId = string.Empty,
                Username = "john"
            });
            Assert.Equal(400, ((BadRequestResult)response).StatusCode);
        }
    }
}
