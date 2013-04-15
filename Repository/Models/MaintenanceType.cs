using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    public partial class MaintenanceType
    {
        public MaintenanceType()
        {
            this.StationMaintenances = new List<StationMaintenance>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public virtual List<StationMaintenance> StationMaintenances { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
