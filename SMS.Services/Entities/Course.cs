using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.Entities
{
    /// <summary>
    /// 课程
    /// </summary>
    public class Course
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual SchoolBook SchoolBook { get; set; }

    }
}
