using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services.Entities
{
    public class Teacher : AccountInfo
    {
        public virtual Class Classes { get; set; }

        public virtual Lesson Lessones { get; set; }

    }
}
