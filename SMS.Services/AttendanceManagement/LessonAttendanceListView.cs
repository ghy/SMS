using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.AttendanceManagement
{
    public class LessonAttendanceListView
    {
        public int AttendanceId { get; set; }

        public int No { get; set; }

        public string StudentName { get; set; }

        public AttendanceType AttendanceType { get; set; }


        public DateTime? AttendanceDateTime { get; set; }


        public string Remark { get; set; }

    }
}
