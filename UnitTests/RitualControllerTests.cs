using System.Net;
using System.Web.Http;
using NSubstitute;
using NUnit.Framework;
using WebApi.Controllers;
using WebApi.Models.Rituals;

namespace UnitTests
{
    [TestFixture]
    public class RitualControllerTests
    {
        private RitualController tested;
        private IRitualRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = Substitute.For<IRitualRepository>();
            tested = new RitualController(repository);
        }

        [Test]
        public void Post_Should_Return_Created_Ritual_When_everything_ok()
        {
            Assert.That(tested.Post(new Ritual { Name = "AshkEnte" }).Name, Is.EqualTo("AshkEnte"));
        }

        [Test]
        public void Post_Should_Store_the_Ritual()
        {
            tested.Post(new Ritual() {Name = "AshkEnte" });
            repository.Received().Register(Arg.Any<Ritual>());
        }

        [Test]
        public void Post_Should_Throw_an_HttpResponseException_When_Ritual_Has_Null_Name()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Post(new Ritual {Name = null}));
            Assert.That(exception.Response.ReasonPhrase,Is.EqualTo("Ritual must have a name"));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Post_Should_Throw_an_HttpResponseException_When_Ritual_Has_Empty_Name()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Post(new Ritual { Name = "" }));
            Assert.That(exception.Response.ReasonPhrase, Is.EqualTo("Ritual must have a name"));
            Assert.That(exception.Response.StatusCode,Is.EqualTo(HttpStatusCode.BadRequest));
        }


        [Test]
        public void Post_Should_Throw_When_Ritual_Is_Null()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Post(null));
            Assert.That(exception.Response.ReasonPhrase, Is.EqualTo("No ritual to create"));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Get_should_return_Ritual_If_it_exists()
        {
            repository.Get("Test").Returns(new Ritual { Name = "Test"});

            var result = tested.Get("Test");

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Get_should_throw_NotFound_Exception_when_ritual_does_not_exist()
        {
            var exception = Assert.Throws<HttpResponseException>(() => tested.Get("Test"));
            Assert.That(exception.Response.StatusCode,Is.EqualTo(HttpStatusCode.NotFound));
        }
    }

    
}
