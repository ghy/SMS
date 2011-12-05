using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMS.Services.Enum;
using Youmay;

namespace SMS.Services.Auth
{
    public class MasterInfoView
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public NameIdView Class { get; set; }
    }
}
