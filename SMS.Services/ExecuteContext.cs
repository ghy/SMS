using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace SMS.Services
{
    public class ExecuteContext : QueryContext
    {
        public ExecuteContext(OperatorInfo operatorInfo, AppContext appContext, ISession session)
            : base(appContext, session)
        {
            OperatorInfo = operatorInfo;
        }

        public OperatorInfo OperatorInfo { get; set; }

        public T Get<T>(object id)
        {
            return base.Session.Get<T>(id);
        }

        public void Save(object obj)
        {
            base.Session.Save(obj);
        }

        public void Update(object obj)
        {
            base.Session.Update(obj);
        }

        public void Delete(object obj)
        {
            base.Session.Delete(obj);
        }

        public IQueryable<T> Query<T>()
        {
            return base.Session.Query<T>();
        }

        public void SaveOrUpdate(object obj)
        {
            base.Session.SaveOrUpdate(obj);
        }
    }
}
