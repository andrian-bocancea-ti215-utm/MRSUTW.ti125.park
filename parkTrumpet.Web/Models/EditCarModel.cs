using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Models
{
    public class EditCarModel
    {
        public int UserId { get; set; } 
        public carDbTable Car { get; set; }
    }
}