using System.Runtime.Serialization;

namespace RestfulAPI.Resources
{
    [DataContract]
    public class ReserveModel
    {
        [DataMember]
        public string Stations { get; set; }
        [DataMember]
        public string User { get; set; }
    }
}
