using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class BatteryCharging
    {
        public int ID { get; set; }
        public int BatteryId { get; set; }
        public System.DateTime EstimatedTime { get; set; }
        public System.DateTime CompletedTime { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual Battery Battery { get; set; }
    }
}
