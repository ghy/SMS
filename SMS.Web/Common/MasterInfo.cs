using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youmay.Web;
using SMS.Services;
using SMS.Services.Auth;

namespace SMS.Web.Common
{
    public class MasterInfo : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    var queries = DependencyResolver.Current.GetService<Repository>();
                    var masterInfo = queries.GetMasterInfo(int.Parse(filterContext.HttpContext.User.Identity.Name));
                    viewResult.ViewData[MvcEnvironment.MasterViewKey] = masterInfo;
                }
            }
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }

}