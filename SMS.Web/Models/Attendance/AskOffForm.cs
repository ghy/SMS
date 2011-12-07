using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS.Services.Enum;
using System.ComponentModel.DataAnnotations;

namespace SMS.Web.Models.Attendance
{
    public class AskOffForm
    {
        public int LessonId { get; set; }

        [Required, StringLength(100)]
        public string AskOffCause { get; set; }
    }
}