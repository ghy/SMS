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

        public int Execute(AttendanceAddView view)
        {
            var student = LogicUtils.NotNull(context.Session.Get<Student>(context.OperatorInfo.OperatorId));
            var lesson = LogicUtils.NotNull(context.Session.Get<Lesson>(context.OperatorInfo.OperatorId));

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

            if (lesson.TakeClassDate < start.AddMinutes(-15) || lesson.TakeClassDate > end)
                throw new AttendanceException(AttendanceExceptionType.NotAttendanceTime);

            var attendace = new Attendance()
            {
                Student = student,
                Lesson = lesson,
                AttendanceType = view.AttendanceType,
                AttendanceDateTime = DateTime.Now,
                Remark = view.Remark
            };

            using (var scope = context.Session.RequestTransaction())
            {
                context.Session.Save(attendace);
                scope.Commit();
            }
            return attendace.Id;
        }

    }
}
