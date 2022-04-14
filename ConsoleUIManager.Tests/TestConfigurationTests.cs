using NUnit.Framework;
using Shouldly;

namespace ConsoleUIManager.Tests
{
    [TestFixture]
    public class TestConfigurationTests
    {
        [Test]
        public void RandomString_GivenLength_ReturnsString()
        {
            var result = TestConfigurations.RandomString(12);

            result.ShouldBeOfType<string>();
        }

        [Test]
        [TestCase(1)]
        [TestCase(54)]
        [TestCase(76)]
        [TestCase(45)]
        [TestCase(3)]
        [TestCase(63)]
        [TestCase(53)]
        [TestCase(21)]
        [TestCase(5)]
        public void RandomString_GivenLength_ReturnsStringOfThatLength(int length)
        {
            var result = TestConfigurations.RandomString(length);

            result.Length.ShouldBe(length);
        }
    }
}