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
using SMS.Services.Enum;

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
        public ActionResult SignIn(int? id) //lessonId
        {
            IdNotNull(id);
            if (ModelState.IsValid)
            {
                try
                {
                    var processor = manager.Create<AddAttendanceProcessor>();
                    processor.Execute(new AttendanceAddView()
                    {
                        SignInAskOff = Services.Enum.SignInAskOff.Singn,
                        LessonId = id.Value
                    });

                    ViewSuccessMessage("签到成功");

                }
                catch (AttendanceException e)
                {
                    if (e.Type == Services.Enum.AttendanceExceptionType.NotAttendanceTime)
                        ViewErrorMessage("只能在上课前15分钟签到!");
                }
            }

            return AjaxJson();
        }


        [HttpPost]
        public ActionResult AskOff(AskOffForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var processor = manager.Create<AddAttendanceProcessor>();
                    processor.Execute(new AttendanceAddView()
                    {
                        SignInAskOff = SignInAskOff.AskOff,
                        LessonId = form.LessonId,
                        Remark = form.AskOffCause
                    });

                    ViewSuccessMessage("请假已成功提交。");
                }
                catch (AttendanceException e)
                {
                    if (e.Type == Services.Enum.AttendanceExceptionType.NotAttendanceTime)
                        ViewErrorMessage("只能在上课前一天请假！");
                }
            }
            return AjaxJson();
        }



        public ActionResult LessonAttendance(int id) //lessonId
        {
            var llaps = manager.Create<ListLessonAttendanceProcessor>().Execute(id);

            return View(new LessonAttendanceViewModel() { LessonAttendances = llaps });

        }

    }
}
