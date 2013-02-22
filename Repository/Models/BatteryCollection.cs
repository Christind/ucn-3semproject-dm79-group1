using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class BatteryCollection
    {
        public int ID { get; set; }
        public int BatteryStorageId { get; set; }
        public int BatteryId { get; set; }
        public virtual Battery Battery { get; set; }
        public virtual BatteryStorage BatteryStorage { get; set; }
    }
}
