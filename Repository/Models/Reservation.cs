using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Station))]
    [KnownType(typeof(User))]
    public partial class Reservation
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int StationId { get; set; }
        [DataMember]
        public DateTime ExpiredDate { get; set; }
        [DataMember]
        public DateTime? CompletedDate { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        public virtual Station Station { get; set; }
        public virtual User User { get; set; }
    }
}
