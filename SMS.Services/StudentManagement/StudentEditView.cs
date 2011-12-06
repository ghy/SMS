using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.StudentManagement
{
    public class StudentEditView
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Remark { get; set; }

        public int ClassId { get; set; }
    }
}
