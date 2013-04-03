using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Edge
    {
        public int ID { get; set; }
        public int StartStation { get; set; }
        public int EndStation { get; set; }
        public decimal Distance { get; set; }
        public decimal Time { get; set; }
    }
}
