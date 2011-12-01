using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.Enum;

namespace SMS.Web.Models.Attendance
{
    public class CreateForm
    {
        public int LessonId { get; set; }

        public AttendanceType AttendanceType { get; set; }

        public string Remark { get; set; }
    }
}