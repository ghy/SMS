using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services.Entities
{
    /// <summary>
    /// 出勤
    /// </summary>
    public class Attendance
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// 课
        /// </summary>
        public virtual Lesson Lesson { get; set; }

        /// <summary>
        /// 学生
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// 出勤时间
        /// </summary>
        public virtual DateTime? AttendanceDateTime { get; set; }

    }
}
