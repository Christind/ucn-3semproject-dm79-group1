using System;
using System.Data.SqlClient;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json.Linq;
using Repository.Models;
using Repository.Resources;

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
        /// <param name="context"> </param>
        public static void LogMessage(Exception ex, string pageName, int logType, WebOperationContext context = null)
        {
            var logRep = new LogRepository();
            string clientInformation = context != null ? GetClientInformation(context.IncomingRequest) : "Not a webrequest";          

            if (ex is SqlException)
            {
                //TODO: Add log message to json/xml file
                //Create the Json file and save it with WriteToFile();
                var jobject =
                    new JObject(
                        new JProperty("Exception",
                            new JObject(
                                new JProperty("CreatedDate", DateTime.Now),
                                new JProperty("ClientInformation", clientInformation),
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
                                        ClientInformation = clientInformation,
                                        CreatedDate = DateTime.Now,
                                        Exception = ex.ToString(),
                                        ExceptionLocation = pageName,
                                        LogType = logType
                                    };
                logRep.Insert(logEntity);
            }
        }

        private static string GetClientInformation(IncomingWebRequestContext context)
        {
            var headerInfo = new StringBuilder();
            foreach (string key in context.Headers.Keys)
            {
                    headerInfo.Append("Session(");
                    headerInfo.Append(key);
                    headerInfo.Append(") - ");
                    headerInfo.Append("<br/>");
            }

            return "UserAgent: " + context.UserAgent + "<br/>" +
                   "Content-Type: " + context.ContentType + "<br/>" +
                   "Header: " + headerInfo + "<br/>";
        }
    }
}
