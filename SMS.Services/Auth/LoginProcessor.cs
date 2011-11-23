using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Entities;
using NHibernate.Linq;
using SMS.Services.Enum;

namespace SMS.Services.Auth
{
    public class LoginProcessor
    {
        private ExecuteContext context;

        public LoginProcessor(ExecuteContext context)
        {
            this.context = context;
        }

        public int Execute(UserLoginView view)
        {
            // var pwd = EncryptUtils.EncryptToSHA1(view.Password);

            var user = (from u in context.Session.Query<AccountInfo>()
                        where u.Account == view.Account &&
                        u.Password == view.Password
                        select u).FirstOrDefault();

            if (user == null)
                throw new LoginException(LoginFailType.AccountOrPasswordWrong);
            else if (user.Status == UserStatus.Disable)
                throw new LoginException(LoginFailType.UserIsDisabled);
            else
                return user.Id;
        }
    }
}
