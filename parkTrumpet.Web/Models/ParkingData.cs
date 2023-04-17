using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace parkTrumpet.Web.Models
{
    public class ParkingData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OwnerData Owner { get; set; }
        public bool hasCamera { get; set; }
        public bool hasBarrier { get; set; }
        public bool hasLotSensor { get; set; }
        public int FreeTime { get; set; }
        public int DayPrice { get; set; }
        public int NightPrice { get; set; }
        public virtual ICollection<LotData> Lots { get; set; }
    }
}