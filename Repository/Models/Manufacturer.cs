using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract]
    [KnownType(typeof(Car))]
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            this.Cars = new List<Car>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Website { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
