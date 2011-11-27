using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Youmay.Web.Paging;
using SMS.Services.Enum;
using System.ComponentModel.DataAnnotations;

namespace SMS.Web.Models.Class
{
    public class IndexForm : PaginationSortForm<ClassSortType>
    {

        [StringLength(100)]
        public string Name { get; set; }

    }
}