using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = false)]
    public partial class ArchiveStation
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int ArchiveId { get; set; }
        [DataMember]
        public decimal StationLat { get; set; }
        [DataMember]
        public decimal StationLong { get; set; }
        [DataMember]
        public virtual Archive Archive { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
