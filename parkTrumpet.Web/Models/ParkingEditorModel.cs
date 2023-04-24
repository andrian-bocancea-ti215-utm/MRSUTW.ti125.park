﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Models
{
    public class ParkingEditorModel
    {
        public parkingDbTable Parking { get; set; }
        public List<lotDbTable>Lots { get; set; }
    }
}