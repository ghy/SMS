using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SMS.Services.Enum;

namespace SMS.Web.Models.Student
{
    public class EditForm
    {
        public int Id { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string FullName { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Remark { get; set; }

        [Required]
        public int ClassId { get; set; }
    }
}