using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Services;
using SMS.Web.Models;
using SMS.Web.Models.Attendance;
using SMS.Services.AttendanceManagement;
using SMS.Web.Common;

namespace SMS.Web.Controllers
{
    public class AttendanceController : ManagementController
    {
        private Repository repository;

        private ProcessorManager manager;

        public AttendanceController(Repository repository, ProcessorManager manager)
        {
            this.repository = repository;
            this.manager = manager;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var processor = manager.Create<AddAttendanceProcessor>();
                    processor.Execute(ConvertTo<AttendanceAddView>(form));

                    ViewSuccessMessage("签到成功");

                }
                catch (AttendanceException e)
                {
                    if (e.Type == Services.Enum.AttendanceExceptionType.NotAttendanceTime)
                        ViewErrorMessage("现在不是上课时间，不能签到");
                }
            }

            return AjaxJson();
        }

    }
}
