using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Repository.Models;

namespace RouteAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRouteService" in both code and config file together.
    [ServiceContract]
    [ServiceKnownType(typeof(User))]
    public interface IRouteService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        User GetUserById(int id);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "RouteAPI.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
