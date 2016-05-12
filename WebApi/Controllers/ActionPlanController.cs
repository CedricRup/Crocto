using System.Net;
using System.Web.Http;
using WebApi.Models.ActionPlans;
using WebApi.Models.Villages;

namespace WebApi.Controllers
{
    public class ActionPlanController : ApiController
    {
        private readonly IVillageRepository villageRepository;

        public ActionPlanController(IVillageRepository villageRepository)
        {
            this.villageRepository = villageRepository;
        }

        [Route("Api/ActionPlan/{villageName}")]
        [HttpPost]
        public void Post(string villageName, ActionPlan actionPlan)
        {
            var village = villageRepository.Get(villageName);
            if (village == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
