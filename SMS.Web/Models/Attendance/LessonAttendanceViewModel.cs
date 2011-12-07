using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.AttendanceManagement;

namespace SMS.Web.Models.Attendance
{
    public class LessonAttendanceViewModel
    {
        public List<LessonAttendanceListView> LessonAttendances { get; set; }
    }
}