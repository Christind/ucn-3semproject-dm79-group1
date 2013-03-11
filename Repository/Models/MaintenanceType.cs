using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public class MaintenanceType
    {
        public MaintenanceType()
        {
            StationMaintenances = new List<StationMaintenance>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<StationMaintenance> StationMaintenances { get; set; }
    }
}