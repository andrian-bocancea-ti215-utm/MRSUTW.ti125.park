using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace parkTrumpet.Web.Models
{
    public class ConsoleForm
    {
        public List<ParkingData> ParkingList { get; set; }
        public string Parking { get; set; }
        public string RegistrationNumber { get; set; }
    }
}