﻿using Foodfeedback.DTO;

namespace Foodfeedback.Services.Interfaces
{
    public interface ILoginService
    {
        bool CheckIfUserExists(UserDTO userDTO);
    }
}
