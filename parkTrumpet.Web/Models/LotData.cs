using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace parkTrumpet.Web.Models
{
    public class LotData
    {
        public int Id { get; set; }
        public ParkingData Parking { get; set; }
        public int Number { get; set; }
        public bool IsActive { get; set; }
    }
}