using System.Net;
using System.Web.Http;
using NSubstitute;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.ActionPlans;
using WebApi.Models.Villages;

namespace UnitTests
{

    // If village does not exist, this should throw an exception
    // Test about everything ok :
    // The village has no ritual
    //  

    [TestFixture]
    public class ActionPlanControllerTests
    {
        [Test]
        public void Should_Throw_Exeption_when_village_does_not_exist()
        {
            IVillageRepository villageRepository = Substitute.For<IVillageRepository>();
            villageRepository.Get("Podunk").Returns((Village)null);

            var tested = new ActionPlanController(villageRepository);
            var exception = Assert.Throws<HttpResponseException>(() => tested.Post("Podunk", null));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void Should_Not_Throw_An_Exception_When_Village_Exists()
        {
            IVillageRepository villageRepository = Substitute.For<IVillageRepository>();
            villageRepository.Get("Podunk").Returns(new Village());

            var tested = new ActionPlanController(villageRepository);
            Assert.DoesNotThrow(()=>tested.Post("Podunk", null));
        }

        [Test]
        public void Should_Tell_The_Village_About_The_Action_Plan()
        {
            IVillageRepository villageRepository = Substitute.For<IVillageRepository>();
            var village = Substitute.For<Village>();
            villageRepository.Get("Podunk").Returns(village);

            var tested = new ActionPlanController(villageRepository);

            ActionPlan actionPlan = new ActionPlan();
            tested.Post("Podunk", actionPlan);
            village.Received().GiveActionPlan(actionPlan);
        }
    }
}
