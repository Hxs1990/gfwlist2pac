using System;
using System.IO;
using System.Net;
using System.Text;

namespace gfwlist2pac
{
    class Network
    {
        public static string network(string url)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("utf-8");
                StreamReader streamReader = new StreamReader(stream, encoding);
                string raw = streamReader.ReadToEnd();
                stream.Close();
                streamReader.Close();
                return raw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }
    }
}
