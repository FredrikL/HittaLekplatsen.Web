using System.IO;
using System.Text;
using FakeItEasy;
using Lekplatser.Api.App_Start;
using Lekplatser.Api.Models;
using Lekplatser.Api.Modules;
using Lekplatser.Api.Repositories;
using Lekplatser.Dto;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;
using Newtonsoft.Json;

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

        [Test]
        public void ShouldGetOriginalPlaygroundFromRepoDuringUpdate()
        {

            var someId = "5193c8df654ed925d4599428";
            var p = new Playground() {Id = someId};
            A.CallTo(() => _playgroundsRepository.GetById(A<string>._)).Returns(A.Dummy<PlaygroundEntity>());

            _browser.Put("/Playgrounds/Update", with => with.Body(ConvertToStream(p), "application/json"));

            A.CallTo(() => _playgroundsRepository.GetById(someId)).MustHaveHappened();
        }

        [Test]
        public void ShouldNotAllowUpdateIfLocationDoesNotMatch()
        {
            var p = new Playground() {Id = "123", Location = new Location(1, 2)};
            var o = new PlaygroundEntity() { Loc= new LocationEntity(){lat= 1, lng= 1}};
            A.CallTo(() => _playgroundsRepository.GetById("123")).Returns(o);

            var result = _browser.Put("/Playgrounds/Update", with => with.Body(ConvertToStream(p), "application/json"));

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void ShouldUpdateIfLocationsIsSame()
        {
            var p = new Playground() { Id = "5193c8df654ed925d4599428", Location = new Location(1, 2) };
            var o = new PlaygroundEntity() { Loc = new LocationEntity() { lat = 1, lng = 2 } };
            A.CallTo(() => _playgroundsRepository.GetById("123")).Returns(o);

            _browser.Put("/Playgrounds/Update", with => with.Body(ConvertToStream(p), "application/json"));

            A.CallTo(() => _playgroundsRepository.Update(A<PlaygroundEntity>._)).MustHaveHappened();
        }

        [Test]
        public void ShouldBePossibleToDeletePlayground()
        {
            var someId = "5193c8df654ed925d4599428";

            _browser.Delete("/Playgrounds/" + someId);

            A.CallTo(() => _playgroundsRepository.Delete(someId)).MustHaveHappened();
        }

        private Stream ConvertToStream<T>(T v)
        {
            string serializeObject = JsonConvert.SerializeObject(v);
            byte[] byteArray = Encoding.ASCII.GetBytes(serializeObject);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }
    }
}