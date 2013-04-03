using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Repository.Models;
using Repository.Resources;

namespace RouteAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RouteService" in both code and config file together.
    public class RouteService : IRouteService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public User GetUserById(int id)
        {
            var userRep = new UserRepository();
            User user = userRep.GetUserById(id);
            return user;
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
