using System.Collections.Generic;

namespace Repository.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Cars = new List<Car>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}