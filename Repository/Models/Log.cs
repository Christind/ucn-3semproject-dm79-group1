using System;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract]
    public partial class Log
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Exception { get; set; }
        [DataMember]
        public string ExceptionLocation { get; set; }
        [DataMember]
        public string ClientInformation { get; set; }
        [DataMember]
        public int LogType { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
