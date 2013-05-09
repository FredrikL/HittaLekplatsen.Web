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

        private IPlaygroundsRepository playgroundsRepository;
        private Browser browser;

        [SetUp]
        public void Setup()
        {
            playgroundsRepository = A.Fake<IPlaygroundsRepository>();
            browser = new Browser(with =>
            {
                with.Module<PlaygroundsModule>();
                with.Dependencies<IPlaygroundsRepository>(playgroundsRepository);
            });
        }

        [Test]
        public void ShouldBePossibleToGetPlaygroundsBasedOnLocation()
        {
            var result = browser.Get("/Playgrounds/GetAll", with =>
            {
                with.HttpRequest();
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}