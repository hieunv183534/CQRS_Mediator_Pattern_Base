using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.IO;

namespace NOM.BACKGROUND.Domain
{
    public static class ReportServices
    {
        const int BUFFER_SIZE = 16 * 1024;

        public static async Task GetReportAsync(string endpoint, string pathFile)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(endpoint);
            req.Method = "GET";
            try
            {
                using (HttpWebResponse svcResponse = (HttpWebResponse)await req.GetResponseAsync())
                {
                    if (svcResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream str = svcResponse.GetResponseStream())
                        {
                            using (FileStream fstr = new FileStream(pathFile, FileMode.OpenOrCreate,
                                                                   FileAccess.Write))
                            {
                                byte[] buffer = new byte[BUFFER_SIZE];
                                int bytesRead;
                                do
                                {
                                    bytesRead = await str.ReadAsync(buffer, 0, BUFFER_SIZE);
                                    await fstr.WriteAsync(buffer, 0, bytesRead);
                                } while (bytesRead > 0);
                                fstr.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> LoginAsync(string endpoint, string userName, string passWord)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(endpoint);
            req.Method = "POST";
            //ContentType
            req.Accept = "application/json";
            req.ContentType = "application/json";
            //Post Data
            byte[] byteArray = Encoding.UTF8.GetBytes("{\"username\": \"" + userName + "\",\"password\": \"" + passWord + "\" }");
            req.ContentLength = byteArray.Length;
            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            try
            {
                using (HttpWebResponse svcResponse = (HttpWebResponse)await req.GetResponseAsync())
                {
                    if (svcResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (StreamReader sr = new StreamReader(svcResponse.GetResponseStream()))
                        {
                           return await sr.ReadToEndAsync();
                        }
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
