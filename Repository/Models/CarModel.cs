using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public class CarModel
    {
        public CarModel()
        {
            Cars = new List<Car>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public decimal Range { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}