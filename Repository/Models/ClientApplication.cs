using System;
using System.Runtime.Serialization;

namespace Repository.Models
{
    public partial class ClientApplication
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string AppKey { get; set; }
        [DataMember]
        public string CryptoKey { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
