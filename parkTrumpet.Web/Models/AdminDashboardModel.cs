using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Models
{
    public class AdminDashboardModel
    {
        public List<parkingDbTable> ParkingList { get; set; }
    }
}