using System.Net;
using System.Web.Http;
using NSubstitute;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Rituals;
using WebApi.Models.Villages;

namespace UnitTests
{
    [TestFixture]
    public class VillageControllerTests
    {
        private VillageController tested;
        private IVillageRepository villageRepository;
        private Ritual ritual;
        private Village village;
        private IRitualRepository ritualRepo;

        [SetUp]
        public void Setup()
        {
            ritual = new Ritual { Name = "myRitual" };
            village = new Village { Name = "myVillage" };
            ritualRepo = Substitute.For<IRitualRepository>();
            villageRepository = Substitute.For<IVillageRepository>();
            tested = new VillageController(villageRepository,ritualRepo);
            StageEveryThingOk();
        }

        [Test]
        public void Post_Should_Return_Created_Village_When_everything_ok()
        {
            Assert.That(tested.Post(new Village() { Name = "Podunk" }).Name, Is.EqualTo("Podunk"));
        }

        [Test]
        public void Post_Should_Store_the_Village()
        {
            tested.Post(new Village() {Name = "Podunk"});
            villageRepository.Received().Register(Arg.Any<Village>());
        }

        [Test]
        public void Post_Should_Throw_an_HttpResponseException_When_Village_Has_Null_Name()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Post(new Village {Name = null}));
            Assert.That(exception.Response.ReasonPhrase,Is.EqualTo("Village must have a name"));
        }

        [Test]
        public void Post_Should_Throw_an_HttpResponseException_When_Village_Has_Empty_Name()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Post(new Village { Name = "" }));
            Assert.That(exception.Response.ReasonPhrase, Is.EqualTo("Village must have a name"));
        }

        [Test]
        public void Post_Should_give_bad_request_status_When_Village_Has_Null_Name()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Post(new Village { Name = null }));
            Assert.That(exception.Response.StatusCode,Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Post_Should_Throw_When_Village_Is_Null()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Post(null));
            Assert.That(exception.Response.StatusCode,Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(exception.Response.ReasonPhrase,Is.EqualTo("No village to create"));
        }

        [Test]
        public void Get_should_return_Village_If_it_exists()
        {
            villageRepository.Get("Test").Returns(new Village {Name = "Test"});

            var result = tested.Get("Test");

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Get_should_throw_NotFound_Exception_when_village_does_not_exist()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Get("Test"));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }


        private void StageEveryThingOk()
        {
            ritualRepo.Get("myRitual").Returns(ritual);
            villageRepository.Get("myVillage").Returns(village);
        }

        [Test]
        public void Post_should_associate_Ritual_and_Village()
        {
            tested.SetRitualForVillage("myVillage", "myRitual");
            Assert.That(village.Ritual, Is.EqualTo(ritual));
        }

        [Test]
        public void Post_should_register_the_village()
        {
            tested.SetRitualForVillage("myVillage", "myRitual");
            villageRepository.Received().Register(village);
        }



        [Test]
        public void Post_should_throw_Exception_when_the_ritual_does_not_exists()
        {
            ritualRepo.Get("myRitual2").Returns<Ritual>((Ritual)null);

            Assert.Throws<HttpResponseException>(() => tested.SetRitualForVillage("myVillage", "myRitual2"));
        }

        [Test]
        public void Post_should_throw_Exception_when_the_village_does_not_exists()
        {
            villageRepository.Get("myVillage").Returns((Village)null);

            Assert.Throws<HttpResponseException>(() => tested.SetRitualForVillage("myVillage", "myRitual"));
        }

        [Test]
        public void Get_Should_return_the_ritual_of_a_village_with_a_ritual()
        {
            village.Ritual = ritual;
            StageEveryThingOk();

            var result = tested.GetRitualForVillage("myVillage");
            Assert.That(result, Is.EqualTo(ritual));
        }
    }

    
}
