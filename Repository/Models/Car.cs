using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Car
    {
        public Car()
        {
            this.UserCars = new List<UserCar>();
        }

        public int ID { get; set; }
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual ICollection<UserCar> UserCars { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
