using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Repository.Models;
using Repository.Resources;

namespace WebAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RouteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RouteService.svc or RouteService.svc.cs at the Solution Explorer and start debugging.
    public class RouteService : IRouteService
    {
        public User GetUserById(int id)
        {
            var userRep = new UserRepository();
            User user = userRep.GetUserById(id);
            return user;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
