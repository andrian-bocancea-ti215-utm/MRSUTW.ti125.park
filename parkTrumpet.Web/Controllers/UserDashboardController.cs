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
    public class UserDashboardController : Controller
    {
        // GET: UserDashboard
        public ActionResult Index()
        {
            var model = new UserDashboardModel();
            model = fillData(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult ShowGarage(int userId)
        {
            var bl = new BusinessLogic.BusinessLogic();
            var model = new GarageModel
            {
                UserId = userId,
                Cars = JsonConvert.DeserializeObject<List<carDbTable>>(bl.RetrieveClientCarList(userId))
            };
            return PartialView("Garage", model);
        }
        [HttpPost]
        public ActionResult ShowEditCar(int carId,int userId)
        {
            var bl = new BusinessLogic.BusinessLogic();
            if (carId == 0)
            {
                var model = new EditCarModel()
                {
                    Car = new carDbTable(),
                    UserId = userId
                };
                return PartialView("EditCar",model);
            }
            else
            {
                var model = new EditCarModel
                {
                    Car = JsonConvert.DeserializeObject<carDbTable>(bl.RetrieveCarData(carId)),
                    UserId = userId
                };
                return PartialView("EditCar", model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult SaveCar(EditCarModel ecmodel)
        {
            var bl = new BusinessLogic.BusinessLogic();
            bl.SaveCarData(JsonConvert.SerializeObject(ecmodel.Car),ecmodel.UserId);
            var model = new GarageModel
            {
                UserId = ecmodel.UserId,
                Cars = JsonConvert.DeserializeObject<List<carDbTable>>(bl.RetrieveClientCarList(ecmodel.UserId))
            };
            return PartialView("Garage", model);
        }
        [HttpPost]
        public ActionResult ShowHistory(int userId)
        {
            var bl = new BusinessLogic.BusinessLogic();
            var model = new HistoryModel
            {
                CompletedSessions = JsonConvert.DeserializeObject<List<parkingSessionDbTable>>
                (bl.RetrieveUserCompletedSessionsList((int)Session["userKey"]))
            };
            return PartialView("History",model);
        }
        public ActionResult Payment (int sessionId)
        {
            var bl = new BusinessLogic.BusinessLogic();
            bl.CompleteSessionPayment(sessionId);
            return new EmptyResult();
        }
        internal UserDashboardModel fillData(UserDashboardModel model)
        {
            if (Session["userKey"] == null) Session["userKey"] = 1;
            var bl = new BusinessLogic.BusinessLogic();
            model.User = JsonConvert.DeserializeObject<clientDbTable>(bl.RetrieveUserData((int)Session["userKey"]));
            model.ActiveSessions = JsonConvert.DeserializeObject<List<parkingSessionDbTable>>
                (bl.RetrieveUserActiveSessionsList((int)Session["userKey"]));
            model.UnpaidSessions = JsonConvert.DeserializeObject<List<parkingSessionDbTable>>
                (bl.RetrieveUserUnpaidSessionsList((int)Session["userKey"]));
            return model;
        }
    }
}