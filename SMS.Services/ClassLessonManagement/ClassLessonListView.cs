using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.ClassLessonManagement
{
    public class ClassLessonListView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime TakeClassDate { get; set; }

        public LessonType LessonType { get; set; }
    }
}
