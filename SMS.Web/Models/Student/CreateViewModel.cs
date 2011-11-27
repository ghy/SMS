using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Models.Student
{
    public class CreateViewModel
    {
        /// <summary>
        /// 性别
        /// </summary>
        public IEnumerable<SelectListItem> Genders { get; set; }

        public IEnumerable<SelectListItem> Classes { get; set; }

        
    }
}