using System;
using System.Net;
using System.IO;
using System.Text;

namespace WineApi
{
    internal class DefaultUrlInvoker : IUrlInvoker
    {
        #region IUrlInvoker Members

        public string InvokeUrl(string url)
        {
            string jsonText = null;

            HttpWebRequest httpWebRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8)) {
                jsonText = streamReader.ReadToEnd();
            }

            return jsonText;
        }

        #endregion
    }
}
