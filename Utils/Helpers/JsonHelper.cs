using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Utils.Helpers
{
    public static class JsonHelper
    {
        public static T DeserializeJson<T>(string url)
        {
            var request = WebRequest.Create(url);
            string text = "";
            var response = (HttpWebResponse)request.GetResponse();
            if (response.GetResponseStream() != null)
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }
            }

            var jsonObj = JsonConvert.DeserializeObject<T>(text);
            return jsonObj;
        }
    }
}
