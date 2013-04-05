using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository.Models;
using Repository.Resources;
using Utils.Helpers;

namespace Logging
{
    public class HandleLogging
    {
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
            var logRep = new LogRepository();
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

            if (ex is SqlException)
            {
                //TODO: Add log message to json/xml file
                //Create the Json file and save it with WriteToFile();
                var jobject =
                    new JObject(
                        new JProperty("Exception",
                            new JObject(
                                new JProperty("CreatedDate", DateTime.Now),
                                new JProperty("ClientInformation", getRemoteIp + "<br/>" + strGetAllSessions.ToString() + "<br/>" +
                                            strGetAllSessions.ToString()),
                                new JProperty("LogType", logType),
                                new JProperty("Exception", ex.ToString()),
                                new JProperty("ExceptionLocation", pageName),
                                new JProperty("IsActive", true)
                                       )
                                     )
                               );

            }
            else
            {
                var logEntity = new Log
                                    {
                                        ClientInformation =
                                            getRemoteIp + "<br/>" + strGetAllSessions.ToString() + "<br/>" +
                                            strGetAllSessions.ToString(),
                                        CreatedDate = DateTime.Now,
                                        Exception = ex.ToString(),
                                        ExceptionLocation = pageName,
                                        IsActive = true,
                                        LogType = logType
                                    };
                logRep.Insert(logEntity);
            }
        }
    }
}
