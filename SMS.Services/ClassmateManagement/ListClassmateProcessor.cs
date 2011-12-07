using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Paging;
using SMS.Services.Entities;
using Youmay.Services.Utils;

namespace SMS.Services.ClassmateManagement
{
    public class ListClassmateProcessor
    {
        private ExecuteContext context;

        public ListClassmateProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public List<ClassmateListView> Execute(int id)
        {
            var cls = LogicUtils.NotNull(context.Session.Get<Class>(id));
            return cls.Students.Select(s => new ClassmateListView()
            {
                No = s.No,
                Email = s.Email,
                Name = s.Name,
                Id = s.Id,
                Gender = s.Gender
            }).ToList();
        }
    }
}
