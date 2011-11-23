using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Services.Entities
{
    public class Student : AccountInfo
    {
        public virtual ICollection<Class> Classes { get; set; }
    }
}
