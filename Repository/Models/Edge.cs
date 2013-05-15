using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Repository.Models
{
    public partial class Edge
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int StartStationId { get; set; }
        [DataMember]
        public virtual Station StartStation { get; set; }
        [DataMember]
        public int EndStationId { get; set; }
        [DataMember]
        public virtual Station EndStation { get; set; }
        [DataMember]
        public decimal Distance { get; set; }
        [DataMember]
        public decimal Time { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

    }
}
