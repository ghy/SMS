using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Entities;
using NHibernate.Linq;
using Youmay.Services.Extensions;
using SMS.Services.Enum;
using Youmay.Paging;
using Youmay;

namespace SMS.Services.StudentManagement
{
    public class ListStudentProcessor
    {
        private ExecuteContext context;

        public ListStudentProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public Pagination<StudentListView> Execute(ListStudentParameters parameters)
        {
            var query = from u in context.Session.Query<Student>()
                        select u;

            if (!string.IsNullOrWhiteSpace(parameters.Account))
            {
                query = query.Where(u => u.Account.Contains(parameters.Account));
            }

            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                query = query.Where(u => u.Name.Contains(parameters.Name));
            }

            if (parameters.Gender.HasValue)
            {
                query = query.Where(u => u.Gender == parameters.Gender);
            }

            if (parameters.Status.HasValue)
            {
                query = query.Where(u => u.Status == parameters.Status);
            }


            //查出符合条件的总记录数
            var total = query.Count();

            //排序
            query = query.AutoOrderBy(parameters.SortConditions, (condition, agent) =>
            {
                switch (condition.SortType)
                {
                    case StudentSortType.Status:
                        agent.OrderBySortDirection(row => row.Status);
                        break;
                    case StudentSortType.CreationDateTime:
                        agent.OrderBySortDirection(row => row.CreationDateTime);
                        break;
                    default:
                        break;
                }
            });

            query = query.Turn(parameters);

            var items = query.ToList().Select(d => new StudentListView
            {
                Id = d.Id,
                Name = d.Name,
                Account = d.Account,
                Status = d.Status,
                Classes = d.Classes.Select(c => new NameIdView(c.Id, c.Name)).ToList()
            }).ToArray();

            return new Pagination<StudentListView>() { Items = items, Total = total };
        }
    }
}
