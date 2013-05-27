using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Repository.Models
{
    [DataContract(IsReference = false)]
    public partial class Station
    {
        public Station()
        {
            this.Reservations = new List<Reservation>();
            this.StationMaintenances = new List<StationMaintenance>();
            this.Edges = new List<Edge>();
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
        [DataMember]
        public virtual BatteryStorage BatteryStorages { get; set; }
        [DataMember]
        public virtual List<Reservation> Reservations { get; set; }
        [DataMember]
        public virtual List<StationMaintenance> StationMaintenances { get; set; }
        [DataMember]
        public virtual List<Edge> Edges { get; set; }
        [DataMember]
        public virtual StationType StationType { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Station) obj);
        }

        protected bool Equals(Station other)
        {
            return ID == other.ID;
        }
    }
}
