using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SinglyAPIExample.Helpers
{
    public static class AppConfig
    {
        /// <summary>
        /// Gets Singly Client Id from config
        /// </summary>
        public static string SinglyClientId
        {
            get { return ConfigurationManager.AppSettings["SinglyClientId"]; }
        }

        /// <summary>
        /// Gets Singly Secret key from config
        /// </summary>
        public static string SinglyClientSecretKey
        {
            get { return ConfigurationManager.AppSettings["SinglyClientSecretKey"]; }
        }

        /// <summary>
        /// Gets Singly API Base URL from config
        /// </summary>
        public static string SinglyApiBaseUrl
        {
            get { return ConfigurationManager.AppSettings["SinglyApiBaseUrl"]; }
        }

        /// <summary>
        /// Gets Singly Auth Base URL from config
        /// </summary>
        public static string SinglyAuthBaseUrl
        {
            get { return ConfigurationManager.AppSettings["SinglyAuthBaseUrl"]; }
        }
    }
}