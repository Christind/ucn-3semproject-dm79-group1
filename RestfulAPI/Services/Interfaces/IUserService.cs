﻿using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        User GetUserById(string id);

        [OperationContract]
        bool EditUserData(User editData);

        [OperationContract]
        bool AuthenticateUser(string userName, string password);
    }
}