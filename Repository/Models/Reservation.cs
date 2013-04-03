using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Reservation
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int StationId { get; set; }
        public System.DateTime ExpiredDate { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual Station Station { get; set; }
        public virtual User User { get; set; }
    }
}
