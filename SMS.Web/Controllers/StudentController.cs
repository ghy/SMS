using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Web.Common;

namespace SMS.Web.Controllers
{
    public class StudentController : ManagementController
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
            return View();
        }

    }
}
