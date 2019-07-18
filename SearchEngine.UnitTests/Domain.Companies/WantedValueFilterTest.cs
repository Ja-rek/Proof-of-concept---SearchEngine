using System;
using Aveneo.SearchEngine.Domain.Companies;
using NUnit.Framework;

namespace Aveneo.SearchEngine.UnitTests.Domain.Companies
{
    internal class WantedValueFilterTest
    {
        [Test]
        [TestCase("pl123-456-32-18"), TestCase("pl 123-456-32-18"), TestCase("123-456-32-18"), TestCase("1234563218")]
        public void Filter_WhenValueContainAnyNumber_ThenReturnsCorrectNumbers(string value)
        {
            var numbers = IdValueFilter.Filter(value);

            Assert.AreEqual(1234563218, numbers);
        }

        [Test]
        public void Filter_WhenValueNotContainAnyNumber_ThenThrowException()
        {
            TestDelegate numbers = () => IdValueFilter.Filter("Any text.");

            Assert.Throws<ApplicationException>(numbers);
        }
    }
}
