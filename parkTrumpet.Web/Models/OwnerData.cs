using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace parkTrumpet.Web.Models
{
    public class OwnerData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ParkingData> Parkings { get; set; }
        public virtual ICollection<AdminAccountsData> Accounts { get; set; }
    }
}