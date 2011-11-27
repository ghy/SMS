using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Paging;
using SMS.Services.Enum;

namespace SMS.Services.ClassManagement
{
    public class ListClassParameters : PaginationSortParameters<ClassSortType>
    {
        public string Name { get; set; }
    }
}
