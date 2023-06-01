using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Models
{
    public class UserDashboardModel
    {
        public clientDbTable User { get; set; }
        public List<parkingSessionDbTable> ActiveSessions { get; set; }
        public List<parkingSessionDbTable> UnpaidSessions { get; set; }
    }
}