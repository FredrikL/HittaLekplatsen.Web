using FakeItEasy;
using Lekplatser.Dto;
using Lekplatser.Web.Api;
using Lekplatser.Web.Repository;
using NUnit.Framework;

namespace Lekplatser.Web.Tests
{
    [TestFixture]
    public class PlaygroundsControllerTests
    {
        [Fake]
        private IPlaygroundsRepository repository;

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
