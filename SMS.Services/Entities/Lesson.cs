using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        /// <summary>
        /// 班组
        /// </summary>
        public virtual Class Class { get; set; }

        /// <summary>
        /// 点名时间
        /// </summary>
        public virtual DateTime RollcallDateTime { get; set; }

        /// <summary>
        /// 开课时间
        /// </summary>
        public virtual DateTime StartDateTime { get; set; }

        /// <summary>
        /// 下课时间
        /// </summary>
        public virtual DateTime EndDateTime { get; set; }
    }
}
