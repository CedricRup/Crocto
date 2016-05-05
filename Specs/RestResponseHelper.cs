using System;
using System.Net;
using NUnit.Framework;
using RestSharp;

namespace Specs
{
    public static class RestResponseHelper
    {
        public static IRestResponse ShouldBeOk(this IRestResponse response)
        {
            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));
            return response;
        }

        public static IRestResponse ShouldBeNoContent(this IRestResponse response)
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            return response;
        }

        public static IRestResponse ToConsole(this IRestResponse response)
        {
            Console.WriteLine(response.Content);
            return response;
        }
    }
}