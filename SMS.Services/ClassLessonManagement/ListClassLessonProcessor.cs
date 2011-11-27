using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Paging;
using SMS.Services.Entities;
using Youmay.Services.Utils;

namespace SMS.Services.ClassLessonManagement
{
    public class ListClassLessonProcessor
    {
        private ExecuteContext context;

        public ListClassLessonProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public List<ClassLessonListView> Execute(int id)
        {
            var cls = LogicUtils.NotNull(context.Session.Get<Class>(id));
            return cls.Lessons.Select(s => new ClassLessonListView()
            {
                Name = s.Name,
                Id = s.Id,
            }).ToList();
        }
    }
}
