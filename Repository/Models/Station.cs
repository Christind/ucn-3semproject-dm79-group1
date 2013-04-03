using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(BatteryStorage))]
    [KnownType(typeof(Reservation))]
    [KnownType(typeof(StationMaintenance))]
    public partial class Station
    {
        public Station()
        {
            this.BatteryStorages = new List<BatteryStorage>();
            this.Reservations = new List<Reservation>();
            this.StationMaintenances = new List<StationMaintenance>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int TypeId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal StationLat { get; set; }
        [DataMember]
        public decimal StationLong { get; set; }
        [DataMember]
        public bool IsOperational { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<BatteryStorage> BatteryStorages { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<StationMaintenance> StationMaintenances { get; set; }
        public virtual StationType StationType { get; set; }
    }
}
