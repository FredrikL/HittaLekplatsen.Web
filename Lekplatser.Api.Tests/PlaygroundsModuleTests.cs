using FakeItEasy;
using Lekplatser.Api.App_Start;
using Lekplatser.Api.Models;
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

        private IPlaygroundsRepository _playgroundsRepository;
        private Browser _browser;

        [SetUp]
        public void Setup()
        {
            _playgroundsRepository = A.Fake<IPlaygroundsRepository>();
            _browser = new Browser(with =>
            {
                with.Module<PlaygroundsModule>();
                with.Dependencies<IPlaygroundsRepository>(_playgroundsRepository);
            });
        }

        [Test]
        public void ShouldBePossibleToGetPlaygroundsBasedOnLocation()
        {
            var result = _browser.Get("/Playgrounds/GetAll");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ShouldBePossibleToSearchForPlaygroundsByLocation()
        {
            _browser.Get("/Playgrounds/GetByLocation", with =>
            {
                with.Query("lat", "55");
                with.Query("long", "13");
                
            });

            A.CallTo(() => _playgroundsRepository.GetByLocation(A<float>._, A<float>._)).MustHaveHappened();
        }

        [TestCase("lat", "")]
        [TestCase("long", "")]
        [TestCase("lat", "a")]
        [TestCase("long", "b")]
        [TestCase("lat", "0x1")]
        public void ShouldReturnBadRequestForInvalidLatOrLong(string key, string value)
        {
            var result = _browser.Get("/Playgrounds/GetByLocation", with => with.Query(key, value));

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void ShouldSendLatToRepository()
        {
            _browser.Get("/Playgrounds/GetByLocation", with =>
            {
                with.Query("lat", "55,1234");
                with.Query("long", "13");

            });

            A.CallTo(() => _playgroundsRepository.GetByLocation(55.1234f, A<float>._)).MustHaveHappened();
        }

        [Test]
        public void ShouldSendLongToRepository()
        {
            _browser.Get("/Playgrounds/GetByLocation", with =>
            {
                with.Query("lat", "55,1234");
                with.Query("long", "13,9876");

            });

            A.CallTo(() => _playgroundsRepository.GetByLocation(A<float>._, 13.9876f)).MustHaveHappened();
        }

        [Test]
        public void ShouldNotCreateAPlaygroundFromEmptyInput()
        {
            _browser.Post("/Playgrounds/Create", with => with.Body(""));

            A.CallTo(() => _playgroundsRepository.Add(A<PlaygroundEntity>._)).MustNotHaveHappened();
        }

        [Test]
        public void ShouldThrowBadRequestForEmptyInput()
        {
            var result =  _browser.Post("/Playgrounds/Create", with => with.Body(""));

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void ShouldNotBeAllowedToUpdatePlaygroundWithouttId()
        {
            var result = _browser.Put("/Playgrounds/Update", with => with.Body("{}"));

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}