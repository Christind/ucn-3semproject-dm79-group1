using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class UserCar
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
