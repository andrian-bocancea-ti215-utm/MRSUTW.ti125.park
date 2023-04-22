using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using parkTrumpet.Web.Models;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace parkTrumpet.Web.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            var model = new UserLoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserLoginModel x)
        {
            var bl = new BusinessLogic.BusinessLogic();
            int key = bl.GetUserAccountKey(x.Username,x.Password);
            if (key == 0)
            {
                x.Message = "Incorrect Data";
                return View(x);
            }
            else
            {
                Session["userKey"] = key;
                return RedirectToAction("Index","UserDashboard");
            }
        }
        public ActionResult ShowRegistration()
        {
            var model = new UserRegistrationModel();
            return View("Registration", model);
        }
        public ActionResult Register(UserRegistrationModel model)
        {
            model.User.PhoneNumber = Regex.Replace(model.User.PhoneNumber, @"s", "");
            var bl = new BusinessLogic.BusinessLogic();
            if (!Regex.IsMatch(model.User.PhoneNumber,"^[0-9]*$"))
            {
                model.Message = "Invalid Phone Number";
                return View("Registration", model);
            }
            if (bl.RegisterUser(JsonConvert.SerializeObject(model.User))==0)
            {
                return View("Index",new UserLoginModel { Message="Registration Succesful"});
            }
            return View("Registration",model);
        }
    }
}