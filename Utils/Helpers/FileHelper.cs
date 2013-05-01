using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Utils.Helpers
{
    public static class FileHelper
    {
        public static bool ResponseFile(HttpRequest request, HttpResponse response, string fileName, string fullPath, long speed, string pageUrl)
        {
            FileStream myFile = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(myFile);
            try
            {
                response.AddHeader("Accept-Ranges", "bytes");
                response.Buffer = false;
                long fileLength = myFile.Length;
                long startBytes = 0;

                const int pack = 10240;
                int sleep = (int)Math.Floor((double)(1000 * pack / speed)) + 1;
                if (request.Headers["Range"] != null)
                {
                    response.StatusCode = 206;
                    string[] range = request.Headers["Range"].Split(new[] { '=', '-' });
                    startBytes = Convert.ToInt64(range[1]);
                }
                response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                if (startBytes != 0)
                {
                    response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                }
                response.AddHeader("Connection", "Keep-Alive");
                response.ContentType = "application/octet-stream";
                response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));

                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

                for (int i = 0; i < maxCount; i++)
                {
                    if (response.IsClientConnected)
                    {
                        response.BinaryWrite(br.ReadBytes(pack));
                        Thread.Sleep(sleep);
                    }
                    else
                    {
                        i = maxCount;
                    }
                }
            }
            finally
            {
                br.Close();
                myFile.Close();
            }

            return true;
        }

        public static bool SaveFile(this Byte[] fileBytes, string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(fileBytes, 0, fileBytes.Length);
            fileStream.Close();
            return true;
        }

        public static void WriteToFile(string data, string fullPath)
        {
            //var myFile = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);



            //IOutputStream outputstream = writestream.GetOutputStreamAt(0);
            //DataWriter datawriter = new DataWriter(outputstream);
            //datawriter.WriteString(data);

            //await datawriter.StoreAsync();
            //outputstream.FlushAsync().Start();
        }

        public static string MapPathReverse(string fullServerPath)
        {
            return @"~\" + fullServerPath.Replace(HttpContext.Current.Request.PhysicalApplicationPath, String.Empty);
        }
    }
}
