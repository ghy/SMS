using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.Entities
{
    /// <summary>
    /// 课
    /// </summary>
    public class Lesson
    {
        public virtual int Id { get; set; }//Id
        public virtual string Name { get; set; }//名称
        public virtual AccountInfo Creator { get; set; }//创建者
        public virtual DateTime CreationDateTime { get; set; }//创建时间

        public virtual string Remark { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// 上课类型
        /// </summary>
        public virtual LessonType LessonType { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        public virtual Class Class { get; set; }

        /// <summary>
        /// 上课老师
        /// </summary>
        public virtual Teacher Teacher { get; set; }

       
    }
}
