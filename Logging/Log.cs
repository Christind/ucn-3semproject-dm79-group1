using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Logging
{
    public class Log
    {
        public int ID { get; set; }
        public string Exception { get; set; } // find a way to convert the Exception to a string?
        public string PageName { get; set; }
        public int LogType { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }

        /// <summary>
        ///  Logtypes:
        ///     1 = exception
        ///     2 = 404 error
        ///     3 = 403 error
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="pageName"></param>
        /// <param name="logType"></param>
        public static void LogMessage(Exception ex, string pageName, int logType)
        {
            string getRemoteIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(getRemoteIp))
                getRemoteIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            StringBuilder strGetAllSessions = new StringBuilder();
            foreach (string key in HttpContext.Current.Session.Keys)
            {
                if (key != "LastError" || key != "LastErrorPageName")
                {
                    strGetAllSessions.Append("Session(");
                    strGetAllSessions.Append(key);
                    strGetAllSessions.Append(") - ");
                    strGetAllSessions.Append(HttpContext.Current.Session[key]);
                    strGetAllSessions.Append("<br/>");
                }
            }

            StringBuilder strGetAllHeaders = new StringBuilder();
            NameValueCollection strAllHeaders = HttpContext.Current.Request.Headers;
            for (int i = 0; i < strAllHeaders.Count; i++)
            {
                strGetAllHeaders.Append(strAllHeaders.GetKey(i));
                strGetAllHeaders.Append(" = ");
                strGetAllHeaders.Append(strAllHeaders.Get(i));
                strGetAllHeaders.Append("<br/>");
            }

            //TODO: Add log message to json/xml file
        }
    }
}