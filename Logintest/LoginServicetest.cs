using Foodfeedback.DTO;
using Foodfeedback.Models;
using Foodfeedback.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Foodfeedbacktests
{
    public class LoginServicetest
    {
        [Fact]
        public void CheckIfUserExists_IfExists_ReturnsTrue()
        {
            var mockSet = new Mock<DbSet<Users>>();
            var mockContext = new Mock<FoodfeedbackDBContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            var service = new Loginservice(mockContext.Object);
            var response = service.CheckIfUserExists(new UserDTO()
            {
                Email = "john89@cesltd.com",
                Password = "welcome"
            });
            Assert.True(response);
        }
    }
}
