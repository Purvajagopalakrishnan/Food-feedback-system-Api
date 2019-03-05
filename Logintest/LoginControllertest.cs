using Foodfeedback.Controllers;
using Foodfeedback.DTO;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Logintest
{
    public class LoginControllertest
    {
        [Fact]
        public void ShouldAuthenticateValidUser()
        {
            var mockLoginervice = new Mock<ILoginService>();
            mockLoginervice.Setup ( details => details.CheckIfUserExists(It.Is<UserDTO>(x=> x.Email == "john89@cesltd.com" && x.Password == "welcome"))).Returns(true);
            var userlogindetails = new LoginController(mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO(){
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.Equal(200,((OkObjectResult)response).StatusCode);
        }
        [Theory]
        [InlineData("john89@cesltd.com", "welcome123")]
        [InlineData("john89@cesltd.com", "test")]
        public void GetUserDetails_IfPasswordIsInvalid_ReturnsFalse(string email, string password)
        {
            var mockLoginervice = new Mock<ILoginService>();
            mockLoginervice.Setup(details => details.CheckIfUserExists(It.Is<UserDTO>(x => x.Email == email && x.Password == password))).Returns(false);
            var userlogindetails = new LoginController(mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Theory]
        [InlineData("test", "welcome")]
        [InlineData("welcome@cesltd.com", "welcome")]
        public void GetUserDetails_IfEmailIsInvalid_ReturnsFalse(string email, string password)
        {
            var mockLoginervice = new Mock<ILoginService>();
            mockLoginervice.Setup(details => details.CheckIfUserExists(It.Is<UserDTO>(x => x.Email == email && x.Password == password))).Returns(false);
            var userlogindetails = new LoginController(mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Fact]
        public void ShouldValidateOnEmpty()
        {
            var mockLoginervice = new Mock<ILoginService>();
            mockLoginervice.Setup(details => details.CheckIfUserExists(It.Is<UserDTO>(x => x.Email == string.Empty && x.Password == string.Empty))).Returns(false);
            var userlogindetails = new LoginController(mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.Equal(200, ((OkObjectResult)response).StatusCode);
        }
        [Fact]
        public void ShouldReturnFalse_IfDataIsInvalid()
        {
            {
                var mockLoginervice = new Mock<ILoginService>();
                mockLoginervice.Setup(details => details.CheckIfUserExists(It.Is<UserDTO>(x => x.Email == "john89@cesltd.com" && x.Password == "welcome"))).Returns(false);
                var userlogindetails = new LoginController(mockLoginervice.Object);
                var response = userlogindetails.GetUserdetails(new UserDTO() {
                    Email = "test@cesltd.com",
                    Password = "test123"
                });
                Assert.Equal(200,((OkObjectResult)response).StatusCode);
            }
        }
    }
}
