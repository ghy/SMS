using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Paging;
using SMS.Services.Entities;
using Youmay.Services.Utils;
using SMS.Services.Enum;

namespace SMS.Services.ClassLessonManagement
{
    public class ListClassLessonProcessor
    {
        private ExecuteContext context;

        public ListClassLessonProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public List<ClassLessonListView> Execute(int id)
        {
            var cls = LogicUtils.NotNull(context.Session.Get<Class>(id));
            var cllv = cls.Lessons.Select(s => new ClassLessonListView()
            {
                TakeClassDate = s.TakeClassDate,
                ExpecteArrivals = s.Attendances == null ? 0 : s.Attendances.Count,
                Arrivals = s.Attendances == null ? 0 : s.Attendances.Where(item => item.AttendanceType == Enum.AttendanceType.Arrive).Count(),
                AskOff = s.Attendances == null ? 0 : s.Attendances.Where(item => item.AttendanceType == Enum.AttendanceType.AskOff).Count(),
                Late = s.Attendances == null ? 0 : s.Attendances.Where(item => item.AttendanceType == Enum.AttendanceType.Late).Count(),
                UnArrivals = s.Attendances == null ? 0 : s.Attendances.Where(item => item.AttendanceType == Enum.AttendanceType.UnArrive).Count(),
                CurrAttendanceType = s.Attendances == null ? null : (s.Attendances.Where(item => item.Student.Id == context.OperatorInfo.OperatorId).FirstOrDefault() == null ? new Nullable<AttendanceType>() : s.Attendances.Where(item => item.Student.Id == context.OperatorInfo.OperatorId).First().AttendanceType),
                Name = s.Name,
                Id = s.Id,
                LessonType = s.LessonType
            }).ToList();




            return cllv;


        }
    }
}
