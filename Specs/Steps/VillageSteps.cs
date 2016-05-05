using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Models.Rituals;
using WebApi.Models.Villages;

namespace Specs.Steps
{
    [Binding]
    public class VillageSteps
    {
        private readonly Village village = new Village();
        private readonly ApiClient client;
        private IRestResponse villageCreationResponse;

        public VillageSteps(WebClientContext clientContext)
        {
            this.client = clientContext.WebClient;
        }

        [Given(@"my village is named ""(.*)""")]
        public void GivenMyVillageIsNamed(string name)
        {
            village.Name = name;
        }

        [Given(@"my village is inhabited by")]
        public void GivenMyVillageIsInhabitedBy(Table table)
        {
            village.Villagers = table.Rows.Select(r => r["Villager"]).ToList();
        }
        
        [When(@"I create my village")]
        public void WhenICreateMyVillage()
        {
            villageCreationResponse = client.CreateVillage(village);
        }
        
        [Then(@"the village creation is a success")]
        public void ThenTheVillageCreationIsASuccess()
        {
            Assert.That(villageCreationResponse.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }
        
        [Then(@"village ""(.*)"" is inhabited by")]
        public void ThenVillageIsInhabitedBy(string villageName, Table villagersTable)
        {
            var village = client.GetVillage(villageName).Data;
            Assert.That(villagersTable.Rows.Select(r=>r["Villager"]),Is.EquivalentTo(village.Villagers));
        }

        [Given(@"a village named ""(.*)"" inhabited by")]
        public void GivenAVillageNamedInhabitedBy(string villageName, Table villagers)
        {
            GivenMyVillageIsNamed(villageName);
            GivenMyVillageIsInhabitedBy(villagers);
            WhenICreateMyVillage();
            villageCreationResponse.ShouldBeOk();
        }

        [Given(@"the village ""(.*)"" must perform the ""(.*)"" ritual")]
        public void GivenTheVillageMustPerformTheRitual(string villageName, string ritual)
        {
            client.AffectRitualToVillage(villageName, ritual).ToConsole().ShouldBeNoContent();
        }

        [Then(@"the ""(.*)"" village has the following remaining actions to do:")]
        public void ThenTheVillageHasTheFollowingRemainingActionsToDo(string villageName, Table table)
        {
            var result = client.GetRitualForVillage(villageName);
            Console.WriteLine(result.Content);
            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.OK));
            table.CompareToSet(result.Data?.Actions ?? new List<RitualAction>());
        }
    }
}
