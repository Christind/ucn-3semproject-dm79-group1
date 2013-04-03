using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Station
    {
        public Station()
        {
            this.BatteryStorages = new List<BatteryStorage>();
            this.Reservations = new List<Reservation>();
            this.StationMaintenances = new List<StationMaintenance>();
        }

        public int ID { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StationLat { get; set; }
        public decimal StationLong { get; set; }
        public bool IsOperational { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual ICollection<BatteryStorage> BatteryStorages { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<StationMaintenance> StationMaintenances { get; set; }
        public virtual StationType StationType { get; set; }
    }
}
