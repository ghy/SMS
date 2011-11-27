using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Entities;
using NHibernate.Linq;
using Youmay.Exceptions;
using Youmay.Services.Utils;

namespace SMS.Services.ClassManagement
{
    public class AddClassProcessor
    {
        private ExecuteContext context;

        public AddClassProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public int Execute(ClassAddView view)
        {
            var cl = (from u in context.Session.Query<Class>()
                      where u.Name == view.Name
                      select u).FirstOrDefault();

            if (cl != null)
                throw new RepeatException("该班级名称已存在");

            var teacher = LogicUtils.NotNull(context.Session.Get<Teacher>(view.TeacherId));

            cl = new Class
            {
                Name = view.Name,
                Teacher = teacher,
                Remark = view.Remark
            };

            using (var scope = context.Session.RequestTransaction())
            {
                context.Session.Save(cl);
                scope.Commit();
            }
            return cl.Id;
        }
    }
}
