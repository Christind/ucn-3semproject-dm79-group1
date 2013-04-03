using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Bookmark
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartLat { get; set; }
        public decimal EndLat { get; set; }
        public decimal StartLong { get; set; }
        public decimal EndLong { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public virtual User User { get; set; }
    }
}
