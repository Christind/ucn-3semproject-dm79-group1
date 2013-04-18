using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = false)]
    public partial class BatteryCollection
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int BatteryStorageId { get; set; }
        [DataMember]
        public int BatteryId { get; set; }
        [DataMember]
        public virtual Battery Battery { get; set; }
        [DataMember]
        public virtual BatteryStorage BatteryStorage { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
