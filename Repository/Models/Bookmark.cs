using System;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    public partial class Bookmark
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal StartLat { get; set; }
        [DataMember]
        public decimal EndLat { get; set; }
        [DataMember]
        public decimal StartLong { get; set; }
        [DataMember]
        public decimal EndLong { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public virtual User User { get; set; }
    }
}
