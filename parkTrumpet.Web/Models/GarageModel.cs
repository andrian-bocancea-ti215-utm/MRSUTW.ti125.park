﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Models
{
    public class GarageModel
    {
        public int UserId { get; set; }
        public List<carDbTable> Cars {get;set;}
    }
}