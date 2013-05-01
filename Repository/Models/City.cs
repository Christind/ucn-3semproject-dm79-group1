using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [DataContract(IsReference = false)]
    public class City
    {
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public int ZipCode { get; set; }
    }
}
