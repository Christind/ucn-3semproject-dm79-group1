using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RouteAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        User GetUserById(int id);
    }
}
