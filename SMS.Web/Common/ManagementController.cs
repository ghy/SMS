using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Youmay.Web;
using System.Web.Mvc;
using Omu.ValueInjecter;
using Youmay.Enums;
using Youmay.Paging;
using Youmay;
using System.IO;
using Youmay.Web.Nhibernate;

namespace SMS.Web.Common
{
    [Authorize(Order = 1)]
    [MasterInfo(Order = 2)]
    [LogError(Order = 3)]
    public abstract class ManagementController : BaseController
    {

        public T ConvertTo<T>(params object[] source) where T : new()
        {
            var obj = new T();
            //  if (typeof(T).BaseType.GetGenericTypeDefinition().Equals(typeof(PaginationSortParameters1<>)))
            if (typeof(T).BaseType.Name.Equals(typeof(PaginationSortParameters<>).Name))
            {
                obj.InjectFrom<PaginationParametersConventionInjection>(source);
            }
            else
            {
                obj.InjectFrom<CommonConventionInjection>(source);
            }
            return obj;
        }

        public class CommonConventionInjection : ConventionInjection
        {
            protected override bool Match(ConventionInfo c)
            {
                return (c.SourceProp.Name.Equals(c.TargetProp.Name, StringComparison.OrdinalIgnoreCase) && c.SourceProp.Type == c.TargetProp.Type)
                    || (c.SourceProp.Name.Equals(c.TargetProp.Name, StringComparison.OrdinalIgnoreCase) && c.SourceProp.Type == typeof(DateRange) && c.TargetProp.Type == typeof(IDateFilterFieldGroup));
            }

            protected override object SetValue(ConventionInfo c)
            {
                if (c.SourceProp.Name.Equals(c.TargetProp.Name, StringComparison.OrdinalIgnoreCase) && c.SourceProp.Type == typeof(DateRange) && c.TargetProp.Type == typeof(IDateFilterFieldGroup))
                {
                    var dateRang = c.SourceProp.Value as DateRange;

                    return dateRang == null ? null : dateRang.ToDateRange();
                }
                if (c.SourceProp.Name.Equals(c.TargetProp.Name, StringComparison.OrdinalIgnoreCase) && c.SourceProp.Type == c.TargetProp.Type)
                {
                    if (c.SourceProp.Type == typeof(string))
                    {
                        return c.SourceProp.Value == null ? null : c.SourceProp.Value.ToString().Trim();
                    }

                    return c.SourceProp.Value;
                }
                return null;
            }
        }

        public class PaginationParametersConventionInjection : ConventionInjection
        {
            protected override bool Match(ConventionInfo c)
            {
                return (c.SourceProp.Name.Equals(c.TargetProp.Name, StringComparison.OrdinalIgnoreCase) && c.SourceProp.Type == c.TargetProp.Type)
                    || (c.SourceProp.Value != null && c.SourceProp.Name == "PageNumber" && c.TargetProp.Name == "StartIndex")
                    || (c.SourceProp.Value != null && c.SourceProp.Name == "PageSize" && c.TargetProp.Name == "MaxCount")
                    || (c.SourceProp.Name.Equals(c.TargetProp.Name, StringComparison.OrdinalIgnoreCase) && c.SourceProp.Type == typeof(DateRange) && c.TargetProp.Type == typeof(IDateFilterFieldGroup));
            }

            protected override object SetValue(ConventionInfo c)
            {
                if (c.SourceProp.Name.Equals(c.TargetProp.Name, StringComparison.OrdinalIgnoreCase) && c.SourceProp.Type == typeof(DateRange) && c.TargetProp.Type == typeof(IDateFilterFieldGroup))
                {
                    var dateRang = c.SourceProp.Value as DateRange;

                    return dateRang == null ? null : dateRang.ToDateRange();
                }

                if (c.SourceProp.Name.Equals(c.TargetProp.Name, StringComparison.OrdinalIgnoreCase) && c.SourceProp.Type == c.TargetProp.Type)
                {
                    return c.SourceProp.Value;
                }
                if (c.SourceProp.Value != null && c.SourceProp.Name == "PageNumber" && c.TargetProp.Name == "StartIndex")
                {
                    dynamic parameters = c.Source;
                    int pageNumber = Convert.ToInt32(c.SourceProp.Value);
                    int startIndex = (pageNumber - 1) * parameters.Value.PageSize;
                    return startIndex;
                }
                if (c.SourceProp.Value != null && c.SourceProp.Name == "PageSize" && c.TargetProp.Name == "MaxCount")
                {
                    return Convert.ToInt32(c.SourceProp.Value);
                }
                return null;
            }
        }


    }

}