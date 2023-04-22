using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using parkTrumpet.Web.Models;
using Newtonsoft.Json;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        public ActionResult Index()
        {
            Session["adminKey"] = "1";
            var bl = new BusinessLogic.BusinessLogic();
            var model = new AdminDashboardModel()
            {
                ParkingList = JsonConvert.DeserializeObject<List<parkingDbTable>>(bl.RetrievePListFromAdKey((string)Session["adminKey"]))
            };
            return View(model);
        }
    }
}