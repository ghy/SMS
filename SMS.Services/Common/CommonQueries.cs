using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay;
using SMS.Services.Entities;

namespace SMS.Services.Common
{
    public static class CommonQueries
    {
        public static List<NameIdView> ListTeacher(this Repository repo)
        {
            var teachers = (from a in repo.Query<Teacher>()
                            select new NameIdView(a.Id, a.Name)).ToList();

            return teachers;
        }

        public static List<NameIdView> ListClass(this Repository repo)
        {
            var cls = (from a in repo.Query<Class>()
                            select new NameIdView(a.Id, a.Name)).ToList();

            return cls;
        }

    }
}
