using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Youmay;

namespace SMS.Services.ClassManagement
{
    public class ClassListView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public NameIdView Teacher { get; set; }

        public string Remark { get; set; }
    }
}
