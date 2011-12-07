using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.ClassLessonManagement
{
    public class ClassLessonListView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime TakeClassDate { get; set; }

        public LessonType LessonType { get; set; }

        /// <summary>
        /// 应到人数
        /// </summary>
        public int? ExpecteArrivals { get; set; }

        /// <summary>
        /// 未到人数
        /// </summary>
        public int UnArrivals { get; set; }

        /// <summary>
        /// 正常到达人数
        /// </summary>
        public int? Arrivals { get; set; }

        /// <summary>
        /// 迟到人数
        /// </summary>
        public int? Late { get; set; }

        /// <summary>
        /// 请假人数
        /// </summary>
        public int? AskOff { get; set; }

        /// <summary>
        /// 当前用户状态
        /// </summary>
        public AttendanceType? CurrAttendanceType { get; set; }
    }
}
