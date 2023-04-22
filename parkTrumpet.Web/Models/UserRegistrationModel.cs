using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Models
{
    public class UserRegistrationModel
    {
        public clientDbTable User { get; set; }
        public string Message { get; set; }
    }
}