using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CASecurity.Web
{
    public class Context
    {
        public static int PageSize
        {
            get
            {
                return Convert.ToInt16(WebConfigurationManager.AppSettings[ConfigKeys.PageSizeKey]);
            }
        }
    }
}