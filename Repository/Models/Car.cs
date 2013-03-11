using System;

namespace Repository.Models
{
    public class Car
    {
        public int ID { get; set; }
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}