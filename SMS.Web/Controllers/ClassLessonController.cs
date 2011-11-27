using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Web.Common;
using SMS.Services;
using SMS.Web.Models;
using SMS.Services.ClassLessonManagement;
using SMS.Web.Models.ClassLesson;

namespace SMS.Web.Controllers
{
    public class ClassLessonController : ManagementController
    {
        private Repository repository;
        private ProcessorManager manager;

        public ClassLessonController(Repository repository, ProcessorManager manager)
        {
            this.repository = repository;
            this.manager = manager;
        }

        public ActionResult Index(int? id)//班级ID
        {
            IdNotNull(id);

            return View(new IndexViewModel(manager.Create<ListClassLessonProcessor>().Execute(id.Value)));
        }

    }
}
