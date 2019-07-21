using Aveneo.SearchEngine.Domain.Companies;
using NUnit.Framework;

namespace Aveneo.SearchEngine.UnitTests.Domain.Companies
{
    internal class PredicateSpecyficationTest
    {
        [Test]
        [TestCase("123-456-32-18"), TestCase("pl123-456-32-18"), TestCase("pl 123-456-32-18")]
        [TestCase("1234563218"), TestCase("123456321")]
        public void Valid_WhenValueIsValid_ThenReturnsTrue(string value)
        {
            var isCorrect = PredicateSpecyfication.Valid(value);

            Assert.True(isCorrect);
        }

        [Test]
        [TestCase("123-46-32-128"), TestCase("pl13-456-32-18"), TestCase("p 123-456-32-18")]
        [TestCase("563218"), TestCase("1234563218955"), TestCase("pl")]
        public void Valid_WhenValueIsNotValid_ThenReturnsFalse(string value)
        {
            var isCorrect = PredicateSpecyfication.Valid(value);

            Assert.False(isCorrect);
        }
    }
}
