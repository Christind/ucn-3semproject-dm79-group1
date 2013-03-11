using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public class Archive
    {
        public Archive()
        {
            ArchiveStations = new List<ArchiveStation>();
        }

        public int ID { get; set; }
        public int UserId { get; set; }
        public decimal StartLat { get; set; }
        public decimal EndLat { get; set; }
        public decimal StartLong { get; set; }
        public decimal EndLong { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<ArchiveStation> ArchiveStations { get; set; }
        public virtual User User { get; set; }
    }
}