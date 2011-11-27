using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Paging;
using NHibernate.Linq;
using SMS.Services.Entities;
using Youmay.Services.Extensions;
using SMS.Services.Enum;
using Youmay.Paging;

namespace SMS.Services.ClassManagement
{
    public class ListClassProcessor
    {
        private ExecuteContext context;

        public ListClassProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public Pagination<ClassListView> Execute(ListClassParameters parameters)
        {
            var query = from u in context.Session.Query<Class>()
                        select u;

            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                query = query.Where(u => u.Name.Contains(parameters.Name));
            }

            //查出符合条件的总记录数
            var total = query.Count();

            //排序
            query = query.AutoOrderBy(parameters.SortConditions, (condition, agent) =>
            {
                switch (condition.SortType)
                {
                    case ClassSortType.CreateDateTime:
                        agent.OrderBySortDirection(row => row.CreationDateTime);
                        break;
                    default:
                        break;
                }
            });

            query = query.Turn(parameters);

            var items = query.ToList().Select(item => new ClassListView
            {
                Id = item.Id,
                Name = item.Name,
                Teacher = new Youmay.NameIdView(item.Teacher.Id, item.Teacher.Name)
            }).ToArray();

            return new Pagination<ClassListView>() { Items = items, Total = total };
        }
    }
}
