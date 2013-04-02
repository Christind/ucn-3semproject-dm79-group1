using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Edge
    {
        public int ID { get; set; }
        public Station StartStation { get; set; }
        public Station EndStation { get; set; }
        public decimal Distance { get; set; }
        public decimal Time { get; set; }
    }
}
