using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodfeedback.DTO
{
    public class FeedbackDTO
    {
        [Required]
        public DateTime SelectDate { get; set; }
        [Required]
        public string TypeOfMeal { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Comments { get; set; }
    }
}
