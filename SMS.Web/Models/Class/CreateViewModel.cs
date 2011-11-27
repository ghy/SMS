using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Models.Class
{
    public class CreateViewModel
    {
        public IEnumerable<SelectListItem> Teachers { get; set; }
    }
}