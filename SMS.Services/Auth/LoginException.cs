using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;

namespace SMS.Services.Auth
{
    public class LoginException : Exception
    {
        public LoginFailType LoginFailType { get; set; }

        public LoginException(LoginFailType type)
        {
            LoginFailType = type;
        }
    }
}
