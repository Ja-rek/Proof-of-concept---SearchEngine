using System;
using Aveneo.SearchEngine.Domain.Companies;
using NUnit.Framework;

namespace Aveneo.SearchEngine.UnitTests.Domain.Companies
{
    internal class FilterPredicateCorrectorTest
    {
        [Test]
        [TestCase("pl123-456-32-18"), TestCase("pl 123-456-32-18"), TestCase("123-456-32-18"), TestCase("1234563218")]
        public void Correct_WhenValueContainAnyNumber_ThenReturnsCorrectNumbers(string value)
        {
            var numbers = FilterPredicateCorrector.Correct(value);

            Assert.AreEqual(1234563218, numbers);
        }

        [Test]
        public void Correct_WhenValueNotContainAnyNumber_ThenThrowException()
        {
            TestDelegate numbers = () => FilterPredicateCorrector.Correct("Any text.");

            Assert.Throws<ApplicationException>(numbers);
        }
    }
}
