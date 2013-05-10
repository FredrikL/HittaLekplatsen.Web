﻿using System.Runtime;
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

        [Test]
        public void ShouldBePossibleToSearchForPlaygroundsByLocation()
        {
            var result = browser.Get("/Playgrounds/GetByLocation", with =>
            {
                with.HttpRequest();
                with.Query("lat", "55");
                with.Query("long", "13");
                
            });

            A.CallTo(() => playgroundsRepository.GetByLocation(A.Dummy<float>(), A.Dummy<float>())).MustHaveHappened();
        }

        [TestCase("lat", "")]
        [TestCase("long", "")]
        [TestCase("lat", "a")]
        [TestCase("long", "b")]
        [TestCase("lat", "0x1")]
        public void ShouldReturnBadRequestForInvalidLatOrLong(string key, string value)
        {
            var result = browser.Get("/Playgrounds/GetByLocation", with =>
            {
                with.HttpRequest();
                with.Query(key, value);
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}