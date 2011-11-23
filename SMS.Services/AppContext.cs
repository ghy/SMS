using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services
{
    public class AppContext
    {
        private IDictionary<string, object> contextMap = new Dictionary<string, object>();

        private object this[string index]
        {
            get { return contextMap[index]; }
            set { contextMap[index] = value; }
        }

        public DateTime Now
        {
            get
            {
                return Convert.ToDateTime(contextMap.ContainsKey("Now") ? this["Now"] : DateTime.Now);
            }
            protected set
            {
                this["Now"] = value;
            }
        }
    }
}   
