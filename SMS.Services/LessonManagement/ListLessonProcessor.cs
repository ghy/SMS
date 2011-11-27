using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Paging;
using NHibernate.Linq;
using SMS.Services.Entities;
using Youmay.Services.Extensions;
using SMS.Services.Enum;

namespace SMS.Services.LessonManagement
{
    public class ListLessonProcessor
    {
        private ExecuteContext context;

        public ListLessonProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public Pagination<LessonListView> Execute(ListLessonParameters parameters)
        {
            return null;
            //var query = from u in context.Session.Query<Lesson>()
            //            select u;

            //if (!string.IsNullOrWhiteSpace(parameters.Name))
            //{
            //    query = query.Where(u => u.Name.Contains(parameters.Name));
            //}

            ////查出符合条件的总记录数
            //var total = query.Count();

            ////排序
            //query = query.AutoOrderBy(parameters.SortConditions, (condition, agent) =>
            //{
            //    switch (condition.SortType)
            //    {
            //        case LessonSortType.CreateDateTime:
            //            agent.OrderBySortDirection(row => row.CreationDateTime);
            //            break;
            //        default:
            //            break;
            //    }
            //});

            //query = query.Turn(parameters);

            //var items = query.ToList().Select(item => new LessonListView
            //{
            //    Id = item.Id,
            //    Name = item.Name,
            //    EndDateTime = item.EndDateTime,
            //    StartDateTime = item.StartDateTime,
            //    Teacher = new Youmay.NameIdView(item.Teacher.Id, item.Teacher.Name)
            //}).ToArray();

            //return new Pagination<LessonListView>() { Items = items, Total = total };
        }
    }
}
