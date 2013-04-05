using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = true)]
    public partial class UserCar
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int CarId { get; set; }
        [DataMember]
        public virtual Car Car { get; set; }
        [DataMember]
        public virtual User User { get; set; }
    }
}

