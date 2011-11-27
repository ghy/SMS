using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Youmay.Web.Paging;
using SMS.Services.StudentManagement;
using System.ComponentModel.DataAnnotations;
using SMS.Services.Enum;

namespace SMS.Web.Models.Lesson
{
    public class IndexForm : PaginationSortForm<LessonSortType>
    {

        [StringLength(100)]
        public string Name { get; set; }


    }
}