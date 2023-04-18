using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using parkTrumpet.Web.Models;

namespace parkTrumpet.Web.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            var model = new AdminLoginModel()
            {
                Failed = false
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AdminLoginModel x)
        {
            var bl = new BusinessLogic.BusinessLogic();
            string key = bl.GetAdminAccountKey(x.Username,x.Password);
            if (key == "0")
            {
                x.Failed = true;
                return View(x);
            }
            else
            {
                Session["userKey"] = key;
                return RedirectToAction("Index","AdminDashboard");
            }
        }
    }
}