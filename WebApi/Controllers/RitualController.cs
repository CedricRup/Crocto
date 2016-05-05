using System.Net;
using System.Web.Http;
using WebApi.Models.HttpHelpers;
using WebApi.Models.Rituals;

namespace WebApi.Controllers
{
    public class RitualController : ApiController
    {
        private readonly IRitualRepository repository;

        public RitualController(IRitualRepository repository)
        {
            this.repository = repository;
        }

        public Ritual Post([FromBody] Ritual ritual)
        {
            if (ritual == null)
            {
                throw HttpResponseHelper.GetHttpResponseException(HttpStatusCode.BadRequest, "No ritual to create");
            }
            if (string.IsNullOrEmpty(ritual.Name))
            {
                throw HttpResponseHelper.GetHttpResponseException(HttpStatusCode.BadRequest, "Ritual must have a name");
            }
            repository.Register(ritual);
            return ritual;
        }

        public Ritual Get(string id)
        {
            var ritual = repository.Get(id);
            if (ritual == null)
                throw HttpResponseHelper.GetHttpResponseException(HttpStatusCode.NotFound, "");
            return ritual;
        }
    }
}