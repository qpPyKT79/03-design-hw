using System.Collections.Generic;
using CloudMaker.Filters;
using NUnit.Framework;

namespace Tests.FiltersTests
{
    [TestFixture]
    public class BoringWordsTest
    {
        private BoringWordsFilter sut;
        [SetUp]
        public void SetUp() => sut = new BoringWordsFilter();

        [Test]
        public void FilterWordsTest_AllBoring()
        {
            var testWords = new List<string> {"of", "as", "the", "versus"};
            var actual = sut.FilterWords(testWords);
            CollectionAssert.IsEmpty(actual);
        }
        [Test]
        public void FilterWordsTest_EmptyInput()
        {
            var testWords = new List<string>();
            var actual = sut.FilterWords(testWords);
            CollectionAssert.IsEmpty(actual);
        }
        [Test]
        public void FilterWordsTest_FiltringNothing()
        {
            var testWords = new List<string> { "NotBoringWord", "NotBoringWordToo", "of", "the" };
            var actual = sut.FilterWords(testWords);
            var excepted = new List<string> { "NotBoringWord", "NotBoringWordToo" };
            CollectionAssert.AreEqual(excepted, actual);
        }
    }
}
