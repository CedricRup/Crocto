using System.Net;
using System.Web.Http;
using WebApi.Models.HttpHelpers;
using WebApi.Models.Rituals;
using WebApi.Models.Villages;

namespace WebApi.Controllers
{
    public class VillageController : ApiController
    {
        private readonly IVillageRepository villageRepository;
        private readonly IRitualRepository ritualRepository;

        public VillageController(IVillageRepository villageRepository,IRitualRepository ritualRepository)
        {
            this.villageRepository = villageRepository;
            this.ritualRepository = ritualRepository;
        }

        public Village Post([FromBody] Village village)
        {
            if (village == null)
            {
                throw HttpResponseHelper.GetHttpResponseException(HttpStatusCode.BadRequest, "No village to create");
            }
            if (string.IsNullOrEmpty(village.Name))
            {
                throw HttpResponseHelper.GetHttpResponseException(HttpStatusCode.BadRequest, "Village must have a name");
            }
            villageRepository.Register(village);
            return village;
        }

        public Village Get(string id)
        {
            var village = villageRepository.Get(id);
            if (village == null)
                throw HttpResponseHelper.GetHttpResponseException(HttpStatusCode.NotFound, string.Empty);
            return village;
        }

        [Route("api/Village/{id}/Ritual")]
        [HttpPost]
        public void SetRitualForVillage(string id, [FromBody] string ritualId)
        {
            var ritual = ritualRepository.Get(ritualId);
            if (ritual == null) { throw new HttpResponseException(HttpStatusCode.Ambiguous); }

            var village = villageRepository.Get(id);
            if (village == null) { throw new HttpResponseException(HttpStatusCode.Ambiguous); }

            village.Ritual = ritual;
            villageRepository.Register(village);
        }

        [Route("api/Village/{id}/Ritual")]
        [HttpGet]
        public Ritual GetRitualForVillage(string id)
        {
            return villageRepository.Get(id).Ritual;
        }
    }
}