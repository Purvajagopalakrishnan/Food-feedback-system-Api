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

namespace FoodFeedbackTests
{
    public class AddFeedbackServiceTest
    {
        [Fact]
        public void AddFeedback_IfValid_ReturnsTrue()
        {
            var mockSet = new Mock<DbSet<Feedback>>();
            var mockContext = new Mock<FoodfeedbackDBContext>();
            mockContext.Setup(c => c.Feedback).Returns(mockSet.Object);
            var service = new AddFeedbackService(mockContext.Object);
            var response = service.AddFeedback(new FeedbackDTO()
            {
                SelectDate = new DateTime(2019, 02, 28),
                TypeOfMeal = "Dinner",
                Rating = 3,
                Comments = "Good"
            });
            Assert.True(response);
        }
    }
}
