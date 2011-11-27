using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youmay.Web.Paging;
using SMS.Services.LessonManagement;
using Youmay.Paging;

namespace SMS.Web.Models.Lesson
{
    public class IndexViewModel : PaginationViewModel<LessonListView>
    {

        public IndexViewModel(IPagination<LessonListView> users, IndexForm form)
            : base(users, form)
        {

        }

        public IEnumerable<SelectListItem> Teachers { get; set; }

    }
}