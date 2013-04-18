using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = false)]
    public partial class Archive
    {
        public Archive()
        {
            this.ArchiveStations = new List<ArchiveStation>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public decimal StartLat { get; set; }
        [DataMember]
        public decimal EndLat { get; set; }
        [DataMember]
        public decimal StartLong { get; set; }
        [DataMember]
        public decimal EndLong { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public virtual List<ArchiveStation> ArchiveStations { get; set; }
        [DataMember]
        public virtual User User { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
