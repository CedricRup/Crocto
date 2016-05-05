using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
            creationResult = client.CreateRitual(ritual);
            Console.WriteLine(creationResult.Content);
        }
        
        [Then(@"the ritual creation is a success")]
        public void ThenTheRitualCreationIsASuccess()
        {
           Assert.That(creationResult.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }
    }

    public class RitualAction
    {
        public string Action { get; set; }
        public int Workload { get; set; }
    }

    public class Ritual
    {
        public string Name { get; set; }
        public List<RitualAction> Actions { get; set; }
    }
}
