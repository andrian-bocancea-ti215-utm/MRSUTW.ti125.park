using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace parkTrumpet.Web.Models
{
    public class AdminLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Failed { get; set; }
    }
}