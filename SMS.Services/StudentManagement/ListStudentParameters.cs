using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay.Paging;
using SMS.Services.Enum;

namespace SMS.Services.StudentManagement
{
    public class ListStudentParameters : PaginationSortParameters<StudentSortType>
    {
        public string Account { get; set; }

        public string Name { get; set; }

        public Gender? Gender { get; set; }

        public UserStatus? Status { get; set; }

    }
}
