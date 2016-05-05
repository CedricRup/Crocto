using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Models.Rituals;

namespace Specs.Steps
{
    [Binding]
    public class RitualSteps
    {
        private Ritual ritual = new Ritual();
        private ApiClient client;
        private IRestResponse creationResult;

        public RitualSteps(WebClientContext context)
        {
            client = context.WebClient;
        }

        [Given(@"my ritual is named ""(.*)""")]
        public void GivenMyRitualIsNamed(string ritualName)
        {
            ritual.Name = ritualName;
        }
        
        [Given(@"my ritual is composed of these actions")]
        public void GivenMyRitualIsComposedOfTheseActions(Table actionsTable)
        {
            ritual.Actions = actionsTable.CreateSet<RitualAction>().ToList();
        }
        
        [When(@"I create my ritual")]
        public void WhenICreateMyRitual()
        {
            creationResult = client.CreateRitual(ritual).ToConsole();
        }
        
        [Then(@"the ritual creation is a success")]
        public void ThenTheRitualCreationIsASuccess()
        {
           Assert.That(creationResult.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"ritual ""(.*)"" has the following actions")]
        public void ThenRitualHasTheFollowingActions(string ritualName, Table actionsTable)
        {
            var response = client.GetRitual(ritualName).ToConsole().ShouldBeOk();
            actionsTable.CompareToSet(ritual.Actions);
        }

        [Given(@"a ritual named ""(.*)"" with the following actions:")]
        public void GivenARitualNamedWithTheFollowingActions(string ritualName, Table actionsTable)
        {
            GivenMyRitualIsNamed(ritualName);
            GivenMyRitualIsComposedOfTheseActions(actionsTable);
            WhenICreateMyRitual();
            creationResult.ShouldBeOk();
        }


    }
}
