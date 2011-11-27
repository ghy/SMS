using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youmay.Web.Paging;
using SMS.Services.StudentManagement;
using Youmay.Paging;

namespace SMS.Web.Models.Student
{
    public class IndexViewModel : PaginationViewModel<StudentListView>
    {

        public IndexViewModel(IPagination<StudentListView> users, IndexForm form)
            : base(users, form)
        {

        }

        public IEnumerable<SelectListItem> Genders { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
}