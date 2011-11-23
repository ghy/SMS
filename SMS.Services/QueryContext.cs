using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SMS.Services
{
    public class QueryContext
    {
        public QueryContext(AppContext appContext, ISession session) 
        {
            AppContext = appContext;
            Session = session;
        }

        public AppContext AppContext { get; set; }

        public ISession Session { get; set; }
    }
}
