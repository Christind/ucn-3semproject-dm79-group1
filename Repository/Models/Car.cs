using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = false)]
    public partial class Car
    {
        public Car()
        {
            this.UserCars = new List<UserCar>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int ManufacturerId { get; set; }
        [DataMember]
        public int ModelId { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public virtual CarModel CarModel { get; set; }
        public virtual List<UserCar> UserCars { get; set; }
        [DataMember]
        public virtual Manufacturer Manufacturer { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
