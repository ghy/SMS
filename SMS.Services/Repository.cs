using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace SMS.Services
{
    public class Repository
    {
        public QueryContext Context { get; set; }

        public Repository(QueryContext context)
        {
            this.Context = context;
        }

        public IQueryable<T> Query<T>()
        {
            return Context.Session.Query<T>();
        }

        public T Get<T>(object id)
        {
            return Context.Session.Get<T>(id);    
        }
    }
}
