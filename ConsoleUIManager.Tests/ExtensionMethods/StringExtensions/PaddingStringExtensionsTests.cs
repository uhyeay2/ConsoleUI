using ConsoleUIManager.ExtensionMethods;
using NUnit.Framework;
using Shouldly;

namespace ConsoleUIManager.Tests.ExtensionMethods.StringExtensions
{
    [TestFixture]
    public class PaddingStringExtensionsTests
    {
        private string _testString = null!;

        [Test]
        [TestCase(100)]
        [TestCase(115)]
        [TestCase(120)]
        [TestCase(125)]
        [TestCase(132)]
        [TestCase(147)]
        public void PadToCenter_GivenStringAndTargetLength_TargetLengthIsCorrect(int targetLength)
        {
            var padded = _testString.PadToCenter(targetLength);

            padded.Length.ShouldBe(targetLength);
        }

        [SetUp]
        public void Setup()
        {
            _testString = TestConfigurations.RandomString(TestConfigurations.RandomNumber());
        }
    }
}