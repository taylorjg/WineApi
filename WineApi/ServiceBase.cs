using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace WineApi
{
    /// <summary>
    /// This is the base class for each of the service classes e.g. CatalogService.
    /// </summary>
    public abstract class ServiceBase
    {
        private string _resource;
        private string _url;

        /// <summary>
        /// Constructor for use by derived classes.
        /// </summary>
        /// <param name="resource">The resource type component of the Url.</param>
        protected ServiceBase(string resource)
        {
            _resource = resource;
            _url = Config.GetBaseUrl(_resource);
        }

        /// <summary>
        /// Append a name/value pair to the query string component of the overall Url.
        /// </summary>
        /// <param name="name">The name of the name/value pair.</param>
        /// <param name="value">The value of the name/value pair.</param>
        protected void AppendNameValueToQueryString(string name, string value)
        {
            _url += string.Format("&{0}={1}", name, value);
        }

        /// <summary>
        /// Execute the query. Issue a http request. Read the response which should be a JSON string.
        /// Use Json.NET to deserialise the JSON string into the required object graph.
        /// </summary>
        /// <typeparam name="T">The type of the object at the root of the object graph.</typeparam>
        /// <returns>The deserialised object graph.</returns>
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

        /// <summary>
        /// Check the ReturnCode property of a given Status object. If it is not 0 then throw
        /// a WineApiStatusException.
        /// </summary>
        /// <param name="status">The Status object to be checked.</param>
        protected void CheckStatus(Status status)
        {
            if (status.ReturnCode != ReturnCode.Success) {
                throw new WineApiStatusException(status);
            }
        }
    }
}
