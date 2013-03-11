using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public class User
    {
        public User()
        {
            Archives = new List<Archive>();
            Bookmarks = new List<Bookmark>();
            Reservations = new List<Reservation>();
            UserCars = new List<UserCar>();
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string APIKey { get; set; }
        public decimal? LocLat { get; set; }
        public decimal? LocLong { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<UserCar> UserCars { get; set; }
    }
}