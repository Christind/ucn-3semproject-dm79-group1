using System;

namespace Repository.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int StationId { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Station Station { get; set; }
        public virtual User User { get; set; }
    }
}