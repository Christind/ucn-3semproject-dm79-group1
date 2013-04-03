using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(BatteryCollection))]
    public partial class BatteryStorage
    {
        public BatteryStorage()
        {
            this.BatteryCollections = new List<BatteryCollection>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int StationId { get; set; }
        [DataMember]
        public int Available { get; set; }
        [DataMember]
        public int Reserved { get; set; }
        [DataMember]
        public int Charging { get; set; }
        [DataMember]
        public virtual ICollection<BatteryCollection> BatteryCollections { get; set; }
        public virtual Station Station { get; set; }
    }
}
