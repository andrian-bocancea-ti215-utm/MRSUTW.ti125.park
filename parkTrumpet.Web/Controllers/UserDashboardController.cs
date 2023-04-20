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
                var model = new EditCarModel();
                return PartialView("EditCar",model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult ShowHistory(int userId)
        {
            var bl = new BusinessLogic.BusinessLogic();
            var model = new GarageModel
            {
                UserId = userId,
                Cars = JsonConvert.DeserializeObject<List<carDbTable>>(bl.RetrieveClientCarList(userId))
            };
            return PartialView("History");
        }
        internal UserDashboardModel fillData(UserDashboardModel model)
        {
            if (Session["userKey"] == null) Session["userKey"] = 1;
            var bl = new BusinessLogic.BusinessLogic();
            model.User = JsonConvert.DeserializeObject<clientDbTable>(bl.RetrieveUserData((int)Session["userKey"]));
            return model;
        }
    }
}