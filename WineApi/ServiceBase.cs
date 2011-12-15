using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace WineApi
{
    public abstract class ServiceBase
    {
        private string _resource;
        private string _url;

        protected ServiceBase(string resource)
        {
            _resource = resource;
            _url = Config.GetBaseUrl(_resource);
        }

        protected void AppendNameValueToQueryString(string name, string value)
        {
            _url += string.Format("&{0}={1}", name, value);
        }

        protected T Execute<T>() where T : class
        {
            T result = null;

            try {
                HttpWebRequest httpWebRequest = HttpWebRequest.Create(_url) as HttpWebRequest;
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8)) {
                    string jsonText = streamReader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<T>(jsonText);
                }
            }
            catch (Exception ex) {
                throw new WineApiServiceException(_resource, ex);
            }

            return result;
        }

        protected void CheckStatus(Status status)
        {
            if (status.ReturnCode != ReturnCode.Success) {
                throw new WineApiStatusException(status);
            }
        }
    }
}
