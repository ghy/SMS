using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youmay.Web.Paging;
using SMS.Services.ClassManagement;
using Youmay.Paging;

namespace SMS.Web.Models.Class
{
    public class IndexViewModel : PaginationViewModel<ClassListView>
    {
        public IndexViewModel(IPagination<ClassListView> users, IndexForm form)
            : base(users, form)
        {

        }
    }
}