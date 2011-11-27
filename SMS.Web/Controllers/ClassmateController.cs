using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Web.Models.Classmate;
using SMS.Services;
using SMS.Web.Models;
using SMS.Services.ClassmateManagement;
using SMS.Web.Common;

namespace SMS.Web.Controllers
{
    public class ClassmateController : ManagementController
    {
        private Repository repository;
        private ProcessorManager manager;

        public ClassmateController(Repository repository, ProcessorManager manager)
        {
            this.repository = repository;
            this.manager = manager;
        }

        public ActionResult Index(int? id)//班级ID
        {
            IdNotNull(id);

            return View(new IndexViewModel(manager.Create<ListClassmateProcessor>().Execute(id.Value)));
        }

    }
}
