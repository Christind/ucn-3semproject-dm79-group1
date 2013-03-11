using System;

namespace Repository.Models
{
    public class StationMaintenance
    {
        public int ID { get; set; }
        public int TypeId { get; set; }
        public int StationId { get; set; }
        public DateTime ExpectedOperationalDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual MaintenanceType MaintenanceType { get; set; }
        public virtual Station Station { get; set; }
    }
}