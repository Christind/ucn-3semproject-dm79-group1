using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Utils.Helpers
{
    public static class JsonHelper
    {
        public static T DeserializeJson<T>(string url, bool isJsonString = false)
        {
            string text = "";
            if (!isJsonString)
            {
                var request = WebRequest.Create(url);
                
                var response = (HttpWebResponse) request.GetResponse();
                if (response.GetResponseStream() != null)
                {
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        text = sr.ReadToEnd();
                    }
                }
            }
            else
            {
                text = url.Replace("/Date(", @"\/Date(").Replace(")/", @")\/");
            }

            var jsonObj = JsonConvert.DeserializeObject<T>(text);
            return jsonObj;
        }

        public static string SerializeJson<T>(T obj)
        {
            var settings = new JsonSerializerSettings() {DateFormatHandling= DateFormatHandling.MicrosoftDateFormat};
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
