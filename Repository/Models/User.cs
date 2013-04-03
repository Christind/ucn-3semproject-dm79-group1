using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract]
    [KnownType(typeof(Archive))]
    [KnownType(typeof(Bookmark))]
    [KnownType(typeof(Reservation))]
    [KnownType(typeof(UserCar))]
    public partial class User
    {
        public User()
        {
            this.Archives = new List<Archive>();
            this.Bookmarks = new List<Bookmark>();
            this.Reservations = new List<Reservation>();
            this.UserCars = new List<UserCar>();
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string APIKey { get; set; }
        [DataMember]
        public decimal? LocLat { get; set; }
        [DataMember]
        public decimal? LocLong { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<UserCar> UserCars { get; set; }
    }
}
