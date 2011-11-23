using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SMS.Web.Common
{
    public class FCSSEnvironment
    {
        public static int CustomerAttachmentTotalMaxSize
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["CustomerAttachmentTotalMaxSize"]);
            }
        }

        public static int CustomerAttachmentMaxSize
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["CustomerAttachmentMaxSize"]);
            }
        }

        public static string[] CustomerAttachmentTypes
        {
            get
            {
                return (ConfigurationManager.AppSettings["CustomerAttachmentTypes"]).Split(',');
            }
        }
    }
}