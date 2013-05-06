using FakeItEasy;
using Lekplatser.Api.App_Start;
using Lekplatser.Api.Modules;
using Lekplatser.Api.Repositories;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;

namespace Lekplatser.Api.Tests
{
    [TestFixture]
    public class PlaygroundsModuleTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            AutoMapperConfig.Configure();
        }

        [Test]
        public void ShouldBePossibleToGetPlaygroundsBasedOnLocation()
        {
            var browser = new Browser(with =>
            {
                with.Module<PlaygroundsModule>();
                with.Dependencies<IPlaygroundsRepository>(A.Fake<IPlaygroundsRepository>());
            });

            var result = browser.Get("/Playgrounds/GetAll", with =>
            {
                with.HttpRequest();
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}