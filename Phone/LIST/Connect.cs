using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.LIST
{
    class Connect
    {
        public static string Conn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Phone.Properties.Settings.Параметр"].ConnectionString;
            }
        }
    }
}
          


