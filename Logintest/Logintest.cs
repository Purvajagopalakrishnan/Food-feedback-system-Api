using Foodfeedback.Controllers;
using Foodfeedback.DTO;
using Foodfeedback.Services.Interfaces;
using Moq;
using Xunit;

namespace Logintest
{
    public class Logintest
    {
        [Fact]
        public void ShouldAuthenticateValidUser()
        {
            var mockLoginervice = new Mock<ILoginService>();
            mockLoginervice.Setup ( details => details.Userdetails(It.Is<UserDTO>(x=> x.Email == "john89@cesltd.com" && x.Password == "welcome"))).Returns(true);
            var userlogindetails = new LoginController(mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO(){
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.True(response);
        }
        [Theory]
        [InlineData("john89@cesltd.com", "welcome123")]
        [InlineData("john89@cesltd.com", "test123")]
        public void GetUserDetails_IfPasswordIsInvalid_ReturnsFalse(string email, string password)
        {
            var mockLoginervice = new Mock<ILoginService>();
            mockLoginervice.Setup(details => details.Userdetails(It.Is<UserDTO>(x => x.Email == email && x.Password == password))).Returns(false);
            var userlogindetails = new LoginController(mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.False(response);
        }
        [Theory]
        [InlineData("test", "welcome")]
        [InlineData("welcome@cesltd.com", "welcome")]
        public void GetUserDetails_IfEmailIsInvalid_ReturnsFalse(string email, string password)
        {
            var mockLoginervice = new Mock<ILoginService>();
            mockLoginervice.Setup(details => details.Userdetails(It.Is<UserDTO>(x => x.Email == email && x.Password == password))).Returns(false);
            var userlogindetails = new LoginController(mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.False(response);
        }
        [Fact]
        public void ShouldValidateOnEmpty()
        {
            var mockLoginervice = new Mock<ILoginService>();
            mockLoginervice.Setup(details => details.Userdetails(It.Is<UserDTO>(x => x.Email == string.Empty && x.Password == string.Empty))).Returns(false);
            var userlogindetails = new LoginController(mockLoginervice.Object);
            var response = userlogindetails.GetUserdetails(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.False(response);
        }
    }
}
