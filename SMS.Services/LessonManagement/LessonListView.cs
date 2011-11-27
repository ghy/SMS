using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay;

namespace SMS.Services.LessonManagement
{
    public class LessonListView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public NameIdView Teacher { get; set; }
    }
}
