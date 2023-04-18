using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using parkTrumpet.BusinessLogic.Interfaces;
using parkTrumpet.BusinessLogic.Core;
using parkTrumpet.Domain.Entities;
using parkTrumpet.Web.Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace parkTrumpet.Web.Controllers
{
    public class ParkingConsoleController : Controller
    {
        // GET: ParkingConsole
        public ActionResult Index()
        {
            var consoleData = new ParkingConsoleModel();
            consoleData = fillData(consoleData);
            return View(consoleData);
        }

        [HttpPost]
        public ActionResult Index(ParkingConsoleModel x, string submit)
        {
            var bl = new BusinessLogic.BusinessLogic();
            if(submit=="arrival")
            {
                bl.ReportCarArrival(x.Parking, x.RegistrationNumber);
            }
            else
            {
                bl.ReportCarDeparture(x.Parking, x.RegistrationNumber);
            }
            fillData(x);
            return View(x);
        }

        internal ParkingConsoleModel fillData(ParkingConsoleModel x)
        {
            var bl = new BusinessLogic.BusinessLogic();
            var plist = JsonConvert.DeserializeObject<List<ParkingData>>(bl.RetrieveParkingList());
            x.ParkingList = plist;
            var slist = JsonConvert.DeserializeObject<List<parkingSessionDbTable>>(bl.RetrieveParkingSessionList());
            x.ParkingSessions = slist;
            return x;
        }
    }
}