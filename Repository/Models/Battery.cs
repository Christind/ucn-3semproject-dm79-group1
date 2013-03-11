using System;

namespace Repository.Models
{
    public class Battery
    {
        public int ID { get; set; }
        public string Serial { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime OutOfCommisionDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}