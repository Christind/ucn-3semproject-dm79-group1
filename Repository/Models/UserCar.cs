using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract]
    [KnownType(typeof(Car))]
    [KnownType(typeof(User))]
    public partial class UserCar
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int CarId { get; set; }
        [DataMember]
        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}

