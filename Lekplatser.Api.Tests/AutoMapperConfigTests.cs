using AutoMapper;
using Lekplatser.Api.App_Start;
using NUnit.Framework;

namespace Lekplatser.Api.Tests
{
    [TestFixture]
    public class AutoMapperConfigTests
    {
        [Test]
        public void AutoMapperConfigsShouldBeValid()
        {
            AutoMapperConfig.Configure();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
