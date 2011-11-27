using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services.Entities
{
    public class Class
    {
        public virtual int Id { get; set; }//Id
        public virtual string Name { get; set; }//名称
        public virtual AccountInfo Creator { get; set; }//创建者
        public virtual DateTime CreationDateTime { get; set; }//创建时间

        public virtual string Remark { get; set; }

        /// <summary>
        /// 班主任
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}
