using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            this.Cars = new List<Car>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
