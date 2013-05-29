using System.Collections.Generic;
using System.Runtime.Serialization;
using Repository.Models;

namespace RestfulAPI.Resources
{
    [DataContract]
    public class ReserveModel
    {
        [DataMember]
        public List<Station> Stations { get; set; }
        [DataMember]
        public string User { get; set; }
    }
}
