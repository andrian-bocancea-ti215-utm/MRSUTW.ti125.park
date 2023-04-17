using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using parkTrumpet.BusinessLogic.Interfaces;
using parkTrumpet.BusinessLogic.Core;


namespace parkTrumpet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;
        public HomeController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        // GET: Home
        public ActionResult Index()
        {
            var bl = new BusinessLogic.BusinessLogic();
            bl.DoTest();

            return View();
        }
    }
}