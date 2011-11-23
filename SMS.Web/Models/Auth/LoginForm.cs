using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SMS.Web.Models.Auth
{
    public class LoginForm
    {
        /// <summary>
        /// 帐号
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}