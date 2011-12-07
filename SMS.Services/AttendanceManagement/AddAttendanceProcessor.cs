using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Entities;
using Youmay.Exceptions;
using Youmay.Services.Utils;
using NHibernate.Linq;
using SMS.Services.Enum;

namespace SMS.Services.AttendanceManagement
{
    public class AddAttendanceProcessor
    {
        private ExecuteContext context;

        public AddAttendanceProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        private void InitAttendance()
        {

        }

        public int Execute(AttendanceAddView view)
        {
            var student = LogicUtils.NotNull(context.Session.Get<Student>(context.OperatorInfo.OperatorId));
            var lesson = LogicUtils.NotNull(context.Session.Get<Lesson>(view.LessonId));

            var currAttendace = (from a in context.Session.Query<Attendance>()
                                 where a.Student.Id == student.Id && a.Lesson.Id == lesson.Id
                                 select a).FirstOrDefault();
            using (var scope = context.Session.RequestTransaction())
            {

                if (lesson.Attendances == null || currAttendace == null)
                {
                    foreach (var stu in lesson.Class.Students)
                    {
                        var curr = (from a in context.Session.Query<Attendance>()
                                    where a.Student.Id == stu.Id && a.Lesson.Id == lesson.Id
                                    select a).FirstOrDefault();
                        if (curr == null)
                        {
                            var attendace = new Attendance()
                            {
                                Student = stu,
                                Lesson = lesson,
                                AttendanceType = AttendanceType.UnArrive,
                            };
                            if (stu.Id == student.Id)
                            {
                                currAttendace = attendace;
                            }
                            context.Session.Save(attendace);
                        }
                    }
                }

                DateTime start = lesson.TakeClassDate;
                DateTime end = lesson.TakeClassDate;

                switch (lesson.LessonType)
                {
                    case LessonType.Morning:
                        start = new DateTime(start.Year, start.Month, start.Day, 10, 0, 0);
                        end = new DateTime(start.Year, start.Month, start.Day, 11, 0, 0);
                        break;
                    case LessonType.Afternoon1:
                        start = new DateTime(start.Year, start.Month, start.Day, 12, 0, 0);
                        end = new DateTime(start.Year, start.Month, start.Day, 14, 0, 0);
                        break;
                    case LessonType.Afternoon2:
                        start = new DateTime(start.Year, start.Month, start.Day, 14, 0, 0);
                        end = new DateTime(start.Year, start.Month, start.Day, 16, 0, 0);
                        break;
                    case LessonType.Evening:
                        start = new DateTime(start.Year, start.Month, start.Day, 20, 0, 0);
                        end = new DateTime(start.Year, start.Month, start.Day, 22, 0, 0);
                        break;
                    default:
                        break;
                }

                if ((view.SignInAskOff == SignInAskOff.Singn) && (lesson.TakeClassDate < start.AddMinutes(-15) || lesson.TakeClassDate > end))
                    throw new AttendanceException(AttendanceExceptionType.NotAttendanceTime);



                if (view.SignInAskOff == SignInAskOff.Singn)
                {
                    if (DateTime.Now > start)
                    {
                        currAttendace.AttendanceType = AttendanceType.Late;
                    }
                    else
                    {
                        currAttendace.AttendanceType = AttendanceType.Arrive;
                    }
                }
                if (view.SignInAskOff == SignInAskOff.AskOff)
                {
                    currAttendace.AttendanceType = AttendanceType.AskOff;
                }

                currAttendace.AttendanceDateTime = DateTime.Now;
                currAttendace.Remark = view.Remark;


                context.Session.Update(currAttendace);
                scope.Commit();
            }
            return currAttendace.Id;
        }

    }
}
