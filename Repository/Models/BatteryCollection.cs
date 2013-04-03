using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Battery))]
    [KnownType(typeof(BatteryStorage))]
    public partial class BatteryCollection
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int BatteryStorageId { get; set; }
        [DataMember]
        public int BatteryId { get; set; }
        [DataMember]
        public virtual Battery Battery { get; set; }
        public virtual BatteryStorage BatteryStorage { get; set; }
    }
}
