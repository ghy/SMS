using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.Enum;

namespace SMS.Web.Models.Lesson
{
    public class CreateForm
    {
        public int ClassId { get; set; }

        public SchoolBook SchoolBook { get; set; }

        public IList<LessonType> LessonTypes { get; set; }


    }
}