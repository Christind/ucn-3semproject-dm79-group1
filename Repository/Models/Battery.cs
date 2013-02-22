using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Battery
    {
        public Battery()
        {
            this.BatteryChargings = new List<BatteryCharging>();
            this.BatteryCollections = new List<BatteryCollection>();
        }

        public int ID { get; set; }
        public string Serial { get; set; }
        public System.DateTime ManufacturingDate { get; set; }
        public System.DateTime OutOfCommisionDate { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual ICollection<BatteryCharging> BatteryChargings { get; set; }
        public virtual ICollection<BatteryCollection> BatteryCollections { get; set; }
    }
}
