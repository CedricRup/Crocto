using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Models.ActionPlans;

namespace Specs.Steps
{
    [Binding]
    public sealed class ActionPlanSteps
    {
        private readonly ApiClient client;

        public ActionPlanSteps(WebClientContext context)
        {
            client = context.WebClient;
        }

        [When(@"the ""(.*)"" village plan for the day is:")]
        public void GivenTheVillagePlanForTheDayIs(string village, Table table)
        {
            ActionPlan actionPlan = new ActionPlan {Actions = table.CreateSet<PlannedAction>().ToList()};

            client.PlanActions(village, actionPlan).ToConsole().ShouldBeNoContent();
        }
    }
}
