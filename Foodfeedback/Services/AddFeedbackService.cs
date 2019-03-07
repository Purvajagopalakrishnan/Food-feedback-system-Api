using Foodfeedback.DTO;
using Foodfeedback.Models;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Foodfeedback.Services
{
    public class AddFeedbackService : IAddFeedbackService
    {
        private readonly FoodfeedbackDBContext _foodfeedbackDBContext;
        public AddFeedbackService(FoodfeedbackDBContext foodfeedbackDBContext)
        {
            _foodfeedbackDBContext = foodfeedbackDBContext;
        }
        /// <summary>
        /// Add feedback to the database
        /// </summary>
        /// <param name="FeedbackDTO"></param>
        /// <returns>
        /// true if feedback added
        /// </returns>
        public bool AddFeedback([FromBody]FeedbackDTO feedbackDTO)
        {
            var entities = new FoodfeedbackDBContext();
            var FeedbackDetails = new Feedback()
            {
                SelectDate = feedbackDTO.SelectDate,
                TypeOfMeal = feedbackDTO.TypeOfMeal,
                Rating = feedbackDTO.Rating,
                Comments = feedbackDTO.Comments
            };
            entities.Feedback.Add(FeedbackDetails);
            entities.SaveChanges();
            return true;
        }
    }
}
