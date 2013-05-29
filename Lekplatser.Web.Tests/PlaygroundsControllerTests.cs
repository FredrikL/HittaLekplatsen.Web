using FakeItEasy;
using Lekplatser.Dto;
using Lekplatser.Shared.Repository;
using Lekplatser.Web.Api;
using NUnit.Framework;

namespace Lekplatser.Web.Tests
{
    [TestFixture]
    public class PlaygroundsControllerTests
    {
        [Fake]
        private IPlaygroundRepository repository;

        [UnderTest]
        private PlaygroundsController controller;

        [SetUp]
        public void Setup()
        {
            Fake.InitializeFixture(this);
        }

        [Test]
        public void ShouldReturnItemsFromRepo()
        {
            A.CallTo(() => repository.GetByLocation(A<float>._, A<float>._)).Returns(new[] {A.Dummy<Playground>()});

            var result = controller.GetByLocation(0, 0);

            Assert.That(result, Is.Not.Empty);
        }
    }
}
