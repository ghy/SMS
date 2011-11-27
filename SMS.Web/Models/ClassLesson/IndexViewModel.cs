using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.ClassLessonManagement;

namespace SMS.Web.Models.ClassLesson
{
    public class IndexViewModel
    {

        public List<ClassLessonListView> ClassLessons
        {
            get;
            private set;
        }

        public IndexViewModel(List<ClassLessonListView> classLessons)
        {
            ClassLessons = classLessons;
        }
    }
}