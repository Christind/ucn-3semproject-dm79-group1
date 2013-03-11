using System;

namespace Repository.Models
{
    public class ClientApplication
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AppKey { get; set; }
        public string CryptoKey { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}