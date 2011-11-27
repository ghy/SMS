using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Models.Lesson
{
    public class CreateViewModel
    {
        public IEnumerable<SelectListItem> Classes { get; set; }

        public IEnumerable<SelectListItem> SchoolBooks { get; set; }

        public IEnumerable<SelectListItem> LessonTypes { get; set; }


    }
}