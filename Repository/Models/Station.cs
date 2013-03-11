using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public class Station
    {
        public Station()
        {
            BatteryStorages = new List<BatteryStorage>();
            Reservations = new List<Reservation>();
        }

        public int ID { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StationLat { get; set; }
        public decimal StationLong { get; set; }
        public bool IsOperational { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<BatteryStorage> BatteryStorages { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual StationType StationType { get; set; }
    }
}