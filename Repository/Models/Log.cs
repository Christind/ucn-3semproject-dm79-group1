using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
