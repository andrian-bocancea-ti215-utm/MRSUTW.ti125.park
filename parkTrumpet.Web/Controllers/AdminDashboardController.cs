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
        public ActionResult ParkingEditor(int parkingId)
        {
            var bl = new BusinessLogic.BusinessLogic();
            var model = new ParkingEditorModel()
            {
                Lots = JsonConvert.DeserializeObject<List<lotDbTable>>(bl.RetrieveParkingLotList(parkingId))
            };
            return View("ParkingEditor",model);
        }
        [HttpPost]
        public ActionResult AddLot(int pId,int x,int y,int t)
        {
            var bl = new BusinessLogic.BusinessLogic();
            bl.AddPLot(pId, x, y, t);
            return new EmptyResult();
        }
        public ActionResult RemoveLot(int pId,int x, int y)
        {
            var bl = new BusinessLogic.BusinessLogic();
            var lots = JsonConvert.DeserializeObject<List<lotDbTable>>(bl.RetrieveParkingLotList(pId));
            foreach (var lot in lots)
            {
                if (x < lot.X + 5 && x > lot.X - 5 && y < lot.Y + 5 && y > lot.Y - 5)
                    bl.RemovePLot(pId, lot.Number);
            }
            return new EmptyResult();
        }
    }
}