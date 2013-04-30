using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class JsonCollectionWrapper<T>
    {
        public List<T> Collection { get; set; }
    }
}