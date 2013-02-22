using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class CarModel
    {
        public CarModel()
        {
            this.Cars = new List<Car>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime Year { get; set; }
        public decimal Range { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
