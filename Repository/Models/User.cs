using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Repository.Models
{
    [DataContract(IsReference = false)]
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
        [DataMember]
        public virtual List<Archive> Archives { get; set; }
        [DataMember]
        public virtual List<Bookmark> Bookmarks { get; set; }
        [DataMember]
        public virtual List<Reservation> Reservations { get; set; }
        [DataMember]
        public virtual List<UserCar> UserCars { get; set; }
    }
}
