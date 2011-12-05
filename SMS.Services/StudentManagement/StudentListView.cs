using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;
using Youmay;

namespace SMS.Services.StudentManagement
{
    public class StudentListView
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public UserStatus Status { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Remark { get; set; }

        public NameIdView Class { get; set; }
    }
}
