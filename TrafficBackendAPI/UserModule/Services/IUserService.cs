﻿using Microsoft.EntityFrameworkCore;
using TrafficBackendAPI.UserModule.Models;

namespace TrafficBackendAPI.UserModule.Services
{
    internal interface IUserService
    {
        Task<(UserModel?, string?)> AddUser(UserModel user);
        Task<(UserModel?, string?)> GetUserById(Guid id);
        Task<(List<UserModel>?, string?)> GetUsers();
    }
}
