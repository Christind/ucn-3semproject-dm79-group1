using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class MaintenanceType
    {
        public MaintenanceType()
        {
            this.StationMaintenances = new List<StationMaintenance>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual ICollection<StationMaintenance> StationMaintenances { get; set; }
    }
}
