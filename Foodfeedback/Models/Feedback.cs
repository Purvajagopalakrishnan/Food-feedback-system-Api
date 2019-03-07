using System;
using System.Collections.Generic;

namespace Foodfeedback.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public DateTime SelectDate { get; set; }
        public string TypeOfMeal { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
