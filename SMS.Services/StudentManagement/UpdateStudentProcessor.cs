using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Entities;
using Youmay.Exceptions;
using Youmay.Services.Utils;

namespace SMS.Services.StudentManagement
{
    public class UpdateStudentProcessor
    {
        private ExecuteContext context;

        public UpdateStudentProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public int Execute(StudentEditView view)
        {
            var student = LogicUtils.NotNull(context.Session.Get<Student>(view.Id));

            //if (student != null)
            //    throw new RepeatException("该用户ID已存在");

            //var user = LogicUtils.NotNull(context.Session.Get<AccountInfo>(context.OperatorInfo.OperatorId));

            //student = new Student
            //{
            //    Account = view.Account,
            //    Password = "3380",
            //    Name = view.FullName,
            //    Role = Role.Student,
            //    CreationDateTime = context.AppContext.Now,
            //    Creator = user,
            //    Email = view.Email,
            //    Gender = view.Gender,
            //    Status = UserStatus.Enable,
            //    Remark = view.Remark,
            //    Class = LogicUtils.NotNull(context.Session.Get<Class>(view.ClassId))
            //};

            //using (var scope = context.Session.RequestTransaction())
            //{
            //    context.Session.Save(student);
            //    scope.Commit();
            //}
            return student.Id;
        }
    }
}
