using System.Runtime.Serialization;

namespace Repository.Models
{
    public partial class Edge
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int StartStation { get; set; }
        [DataMember]
        public Station StartStationObj { get; set; }
        [DataMember]
        public int EndStation { get; set; }
        [DataMember]
        public Station EndStationObj { get; set; }
        [DataMember]
        public decimal Distance { get; set; }
        [DataMember]
        public decimal Time { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

    }
}
