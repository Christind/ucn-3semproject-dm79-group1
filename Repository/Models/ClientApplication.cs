using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ClientApplication
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AppKey { get; set; }
        public string CryptoKey { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
