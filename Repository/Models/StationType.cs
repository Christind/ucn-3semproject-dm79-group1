using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = false)]
    public partial class StationType
    {
        public StationType()
        {
            this.Stations = new List<Station>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public virtual List<Station> Stations { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
