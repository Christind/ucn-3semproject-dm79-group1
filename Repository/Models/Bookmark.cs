using System;

namespace Repository.Models
{
    public class Bookmark
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
        public DateTime CreatedDate { get; set; }
        public virtual User User { get; set; }
    }
}