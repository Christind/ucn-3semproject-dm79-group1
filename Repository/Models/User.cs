using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class User
    {
        public User()
        {
            this.Archives = new List<Archive>();
            this.Bookmarks = new List<Bookmark>();
            this.Reservations = new List<Reservation>();
            this.UserCars = new List<UserCar>();
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string APIKey { get; set; }
        public Nullable<decimal> LocLat { get; set; }
        public Nullable<decimal> LocLong { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<UserCar> UserCars { get; set; }
    }
}
