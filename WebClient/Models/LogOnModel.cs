using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Repository.Models;
using Utils.Helpers;

namespace WebClient.Models
{
    public class LogOnModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string UserName { get; set; }
        [DataMember]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsValid(string userName, string password)
        {
            return JsonHelper.DeserializeJson<bool>(String.Format("http://localhost:8732/auth/{0}@{1}", userName, password));
        }
    }
}