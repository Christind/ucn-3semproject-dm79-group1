using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class StationType
    {
        public StationType()
        {
            this.Stations = new List<Station>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual ICollection<Station> Stations { get; set; }
    }
}
