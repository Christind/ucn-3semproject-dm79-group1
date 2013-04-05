using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    public partial class Battery
    {
        public Battery()
        {
            this.BatteryChargings = new List<BatteryCharging>();
            this.BatteryCollections = new List<BatteryCollection>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Serial { get; set; }
        [DataMember]
        public DateTime ManufacturingDate { get; set; }
        [DataMember]
        public DateTime OutOfCommisionDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public virtual List<BatteryCharging> BatteryChargings { get; set; }
        [DataMember]
        public virtual List<BatteryCollection> BatteryCollections { get; set; }
    }
}
