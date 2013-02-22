using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class StationMaintenance
    {
        public int ID { get; set; }
        public int TypeId { get; set; }
        public int StationId { get; set; }
        public System.DateTime ExpectedOperationalDate { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual MaintenanceType MaintenanceType { get; set; }
        public virtual Station Station { get; set; }
    }
}
