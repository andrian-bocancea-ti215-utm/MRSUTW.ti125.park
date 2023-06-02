using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Models
{
    public class HistoryModel
    {
        public List<parkingSessionDbTable> CompletedSessions { get; set; }

    }
}