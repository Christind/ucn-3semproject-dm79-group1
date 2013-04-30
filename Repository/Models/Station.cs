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
        }

        [DataMember]
        //[JsonConverter(typeof(Int32))] 
        public int ID { get; set; }
        [DataMember]
        //[JsonConverter(typeof(Int32))] 
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
        public virtual StationType StationType { get; set; }
    }
}
