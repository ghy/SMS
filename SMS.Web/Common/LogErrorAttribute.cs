using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;


namespace SMS.Web.Common
{
    public class LogErrorAttribute : HandleErrorAttribute, IExceptionFilter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LogErrorAttribute));

        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            if (ex != null)
            {
                log.Error(ex.Message, ex);
            }

            base.OnException(context);
        }

    }
}