using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services.Entities
{
    public class Student : AccountInfo
    {
        /// <summary>
        /// 学号
        /// </summary>
        public virtual int No { get; set; }

        public virtual Class Class { get; set; }

    }
}
