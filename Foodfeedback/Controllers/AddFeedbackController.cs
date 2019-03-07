using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodfeedback.DTO;
using Foodfeedback.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foodfeedback.Controllers
{
    [Route("api/addfeedback")]
    public class AddFeedbackController : Controller
    {
        private readonly IAddFeedbackService _addFeedbackService;
        public AddFeedbackController(IAddFeedbackService addFeedbackService)
        {
            _addFeedbackService = addFeedbackService;
        }
        [HttpPost]
        /// <summary>
        /// call the service and add feedback
        /// </summary>
        public IActionResult AddFoodFeedback([FromBody]FeedbackDTO feedbackDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _addFeedbackService.AddFeedback(feedbackDTO);
                    if(result == true)
                    {
                        return Ok(result);
                    }
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
        }
    }
}