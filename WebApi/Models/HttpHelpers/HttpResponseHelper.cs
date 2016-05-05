using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Models.HttpHelpers
{
    internal static class HttpResponseHelper
    {
        public static HttpResponseException GetHttpResponseException(HttpStatusCode httpStatusCode, string reason)
        {
            var resp = new HttpResponseMessage(httpStatusCode)
            {
                ReasonPhrase = reason
            };
            return new HttpResponseException(resp);
        }
    }
}