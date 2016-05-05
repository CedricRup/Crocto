using System.Net;
using System.Web.Http;
using WebApi.Models.HttpHelpers;
using WebApi.Models.Rituals;

namespace WebApi.Controllers
{
    public class TestController : ApiController
    {

        [Route("Village/{village}/Ritual")]
        [HttpPost]
        public void Post(string village,[FromBody]string id)
        {

        }

        [Route("Village/{village}/Ritual")]
        [HttpGet]
        public void Get()
        {

        }
    }
}