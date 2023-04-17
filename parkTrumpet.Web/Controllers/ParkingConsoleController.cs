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

namespace parkTrumpet.Web.Controllers
{
    public class ParkingConsoleController : Controller
    {
        // GET: ParkingConsole
        public ActionResult Index()
        {
            var consoleData = new ConsoleForm();
            consoleData.ParkingList = getParkingList();
            return View(consoleData);
        }

        [HttpPost]
        public ActionResult Index(ConsoleForm x, string submit)
        {
            var bl = new BusinessLogic.BusinessLogic();
            if(submit=="arrival")
            {
                bl.ReportCarArrival(x.Parking, x.RegistrationNumber);
            }
            x.ParkingList = getParkingList();
            return View(x);
        }

        internal List<ParkingData> getParkingList()
        {
            var bl = new BusinessLogic.BusinessLogic();
            var DbList = bl.RetrieveParkingList();

            var list = new List<ParkingData>();

            foreach (var line in DbList)
            {
                ParkingData x = new ParkingData
                {
                    Name = line.Name
                };
                list.Add(x);
            }
            return(list);
        }
    }
}