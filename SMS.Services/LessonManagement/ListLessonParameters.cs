using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Paging;
using SMS.Services.Enum;

namespace SMS.Services.LessonManagement
{
    public class ListLessonParameters : PaginationSortParameters<LessonSortType>
    {
        public string Name { get; set; }
    }
}
