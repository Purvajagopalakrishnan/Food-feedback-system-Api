using Foodfeedback.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodfeedback.Services.Interfaces
{
    public interface IRegistrationService
    {
        bool RegisterUser(RegistrationDTO registrationDTO);
    }
}
