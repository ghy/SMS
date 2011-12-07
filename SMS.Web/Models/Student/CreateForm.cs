using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.Enum;
using System.ComponentModel.DataAnnotations;

namespace SMS.Web.Models.Student
{
    public class CreateForm
    {
        [Required]
        public string Account { get; set; }

        [Required]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Remark { get; set; }

        [Required]
        public IList<int> ClassIds { get; set; }
    }
}