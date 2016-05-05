
using System;

namespace Specs.Steps
{
    public class WebClientContext
    {
        public WebClientContext()
        {
            WebClient = new ApiClient(new Uri("http://localhost:12345/api"));
        }

        public ApiClient WebClient { get; private set; }
    }
}
