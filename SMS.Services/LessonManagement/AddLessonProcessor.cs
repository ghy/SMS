using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Entities;
using NHibernate.Linq;
using Youmay.Exceptions;
using Youmay.Services.Utils;

namespace SMS.Services.LessonManagement
{
    public class AddLessonProcessor
    {
        private ExecuteContext context;

        public AddLessonProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public int Execute(LessonAddView view)
        {

            return 0;
            //var lesson = (from u in context.Session.Query<Lesson>()
            //              where u.Name == view.Name
            //              select u).FirstOrDefault();

            //if (lesson != null)
            //    throw new RepeatException("该班级名称已存在");

            //var user = LogicUtils.NotNull(context.Session.Get<AccountInfo>(context.OperatorInfo.OperatorId));
            //var cls = LogicUtils.NotNull(context.Session.Get<Class>(view.ClassId));
            //var teacher = LogicUtils.NotNull(context.Session.Get<Teacher>(view.TeacherId));

            //lesson = new Lesson
            //{
            //    Name = view.Name,
            //    Creator = user,
            //    CreationDateTime = DateTime.Now,

            //    Teacher = teacher,
            //    Class = cls,
            //    Remark = view.Remark,
            //};

            //using (var scope = context.Session.RequestTransaction())
            //{
            //    context.Session.Save(lesson);
            //    scope.Commit();
            //}
            //return lesson.Id;
        }
    }
}
