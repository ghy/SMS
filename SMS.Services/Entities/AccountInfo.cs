using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.Entities
{
    public abstract class AccountInfo 
    {
        public virtual int Id { get; set; }//Id
        public virtual string Name { get; set; }//名称
        public virtual AccountInfo Creator { get; set; }//创建者
        public virtual DateTime CreationDateTime { get; set; }//创建时间
        public virtual string Account { get; set; }//账号
        public virtual string Password { get; set; }//密码
        public virtual UserStatus Status { get; set; }//状态
        public virtual Gender Gender { get; set; }//性别
    }
}
