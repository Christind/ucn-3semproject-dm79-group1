using System;

namespace Repository.Models
{
    public class BatteryCharging
    {
        public int ID { get; set; }
        public int BatteryId { get; set; }
        public DateTime EstimatedTime { get; set; }
        public DateTime CompletedTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Battery Battery { get; set; }
    }
}