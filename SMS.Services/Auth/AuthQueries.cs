using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Entities;
using Youmay.Services.Utils;

namespace SMS.Services.Auth
{
    public static class AuthQueries
    {
        public static MasterInfoView GetMasterInfo(this Repository repo, int currentUserId)
        {
            var user = LogicUtils.NotNull(repo.Get<AccountInfo>(currentUserId));

            var master = new MasterInfoView
            {
                Id = user.Id,
                Account = user.Account,
                Name = user.Name,
                Role = user.Role,
            };

            return master;
        }
    }
}
