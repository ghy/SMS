using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Services.Utils;
using SMS.Services.Entities;

namespace SMS.Services.AttendanceManagement
{
    public class ListLessonAttendanceProcessor
    {
        private ExecuteContext context;

        public ListLessonAttendanceProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public List<LessonAttendanceListView> Execute(int id)//lessonId
        {
            var lesson = LogicUtils.NotNull(context.Session.Get<Lesson>(id));

            return lesson.Attendances.Select(item => new LessonAttendanceListView()
              {

                  AttendanceDateTime = item.AttendanceDateTime,
                  AttendanceId = item.Id,
                  No = item.Student.No,
                  AttendanceType = item.AttendanceType,
                  Remark = item.Remark,
                  StudentName = item.Student.Name
              }).ToList();

        }
    }
}
