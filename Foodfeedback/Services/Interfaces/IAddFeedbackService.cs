using Foodfeedback.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodfeedback.Services.Interfaces
{
    public interface IAddFeedbackService
    {
        bool AddFeedback(FeedbackDTO FeedbackDTO);
    }
}
