using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.Enum;

namespace SMS.Web.Models.Student
{
    public class CreateForm
    {
        public string Account { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Remark { get; set; }

        public IList<int> ClassIds { get; set; }
    }
}