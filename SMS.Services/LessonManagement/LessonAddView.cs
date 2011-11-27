using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services.LessonManagement
{
    public class LessonAddView
    {
        public string Name { get; set; }

        public int ClassId { get; set; }

        /// <summary>
        /// 老师
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// 点名时间
        /// </summary>
        public DateTime RollcallDateTime { get; set; }

        /// <summary>
        /// 开课时间
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// 下课时间
        /// </summary>
        public DateTime EndDateTime { get; set; }


        public string Remark { get; set; }
    }
}
