using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Youmay.Web.Paging;
using SMS.Services.StudentManagement;
using System.ComponentModel.DataAnnotations;
using SMS.Services.Enum;

namespace SMS.Web.Models.Student
{
    public class IndexForm : PaginationSortForm<StudentSortType>
    {
        [StringLength(20)]
        public string Account { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public Gender? Gender { get; set; }

        public UserStatus? Status { get; set; }
    }
}