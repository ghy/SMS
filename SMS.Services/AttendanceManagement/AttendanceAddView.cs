using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.AttendanceManagement
{
    public class AttendanceAddView
    {
        public int LessonId { get; set; }

        public SignInAskOff SignInAskOff { get; set; }

        public string Remark { get; set; }
    }
}
