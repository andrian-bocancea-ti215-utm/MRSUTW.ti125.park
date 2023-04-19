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
        public ActionResult ShowGarage(UserDashboardModel userModel)
        {
            var bl = new BusinessLogic.BusinessLogic();
            userModel = fillData(userModel);
            var model = new GarageModel
            {
                Cars = JsonConvert.DeserializeObject<List<carDbTable>>(bl.RetrieveClientCarList(userModel.User.Id))
            };
            return PartialView("Garage", model);
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