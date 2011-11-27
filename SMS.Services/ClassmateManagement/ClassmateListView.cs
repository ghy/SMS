using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.ClassmateManagement
{
    public class ClassmateListView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }
    }
}
