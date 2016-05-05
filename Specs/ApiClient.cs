using System;
using RestSharp;
using WebApi.Models.ActionPlans;
using WebApi.Models.Rituals;
using WebApi.Models.Villages;

namespace Specs
{
    public class ApiClient
    {
        private readonly IRestClient client;

        public ApiClient(Uri adresse)
        {
            client = new RestClient {BaseUrl = adresse};
        }

        public IRestResponse CreateVillage(Village village)
        {
            var restRequest = new RestRequest("Village", Method.POST) {RequestFormat = DataFormat.Json};
            restRequest.AddBody(village);
            return client.Execute(restRequest);
        }

        public IRestResponse<Village> GetVillage(string village)
        {
            var request = new RestRequest("Village/{villageName}");
            request.AddParameter("villageName", village, ParameterType.UrlSegment);
            return client.Execute<Village>(request);
        }

        public IRestResponse CreateRitual(Ritual ritual)
        {
            var restRequest = new RestRequest("Ritual", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(ritual);
            return client.Execute(restRequest);
        }

        public IRestResponse<Ritual> GetRitual(string ritualName)
        {
            var request = new RestRequest("Ritual/{ritualName}");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("ritualName", ritualName, ParameterType.UrlSegment);
            return client.Execute<Ritual>(request);
        }

        

        public IRestResponse PlanActions(string village, ActionPlan actionPlan)
        {
            var request = new RestRequest("ActionPlan/{village}", Method.POST) {RequestFormat = DataFormat.Json};
            request.AddParameter("village", village, ParameterType.UrlSegment);
            request.AddBody(actionPlan);
            return client.Execute(request);
        }

        public IRestResponse AffectRitualToVillage(string village, string ritual)
        {
            var request = new RestRequest("Village/{village}/Ritual", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddParameter("village", village, ParameterType.UrlSegment);
            request.AddBody(ritual);
            return client.Execute(request);
        }

        public IRestResponse<Ritual> GetRitualForVillage(string village)
        {
            var request = new RestRequest("Village/{village}/Ritual");
            request.AddParameter("village", village, ParameterType.UrlSegment);
            return client.Execute<Ritual>(request);
        }
    }
}
