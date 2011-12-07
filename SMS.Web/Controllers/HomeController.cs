using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Web.Common;

namespace SMS.Web.Controllers
{
    public class HomeController : ManagementController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Built()
        {
            return View();
        }

    }
}
