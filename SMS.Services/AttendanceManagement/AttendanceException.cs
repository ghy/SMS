using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.AttendanceManagement
{
    public class AttendanceException : Exception
    {
        public AttendanceExceptionType Type { get; set; }

        public AttendanceException(AttendanceExceptionType type)
        {
            this.Type = type;
        }
    }
}
