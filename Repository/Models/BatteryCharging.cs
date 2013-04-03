using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Battery))]
    public partial class BatteryCharging
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int BatteryId { get; set; }
        [DataMember]
        public DateTime EstimatedTime { get; set; }
        [DataMember]
        public DateTime CompletedTime { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public virtual Battery Battery { get; set; }
    }
}
