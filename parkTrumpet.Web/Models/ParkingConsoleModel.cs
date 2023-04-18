using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Models
{
    public class ParkingConsoleModel
    {
        public List<ParkingData> ParkingList { get; set; }
        public string Parking { get; set; }
        public string RegistrationNumber { get; set; }
        public List<parkingSessionDbTable> ParkingSessions { get; set; }

    }
}