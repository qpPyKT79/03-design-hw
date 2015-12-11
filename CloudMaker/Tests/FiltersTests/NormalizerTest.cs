using System.Collections.Generic;
using NUnit.Framework;

namespace CloudMaker.Filters
{
    [TestFixture]
    class NormalizerTest
    {
        private Normalizer sut;

        [SetUp]
        public void SetUp() => sut = new Normalizer();

        [Test]
        public void NormalizeWordTest()
        {
            var testWords = new List<string> { "counting","thinks" };
            var actual = sut.FilterWords(testWords);
            var excepted = new List<string> {"count","think"};
            CollectionAssert.AreEqual(excepted, actual);
        }

        [Test]
        public void NormalizeWord_NothingNormilize()
        {
            var testWords = new List<string> {"computer", "fruit", "number" };
            var actual = sut.FilterWords(testWords);
            var excepted = new List<string> { "computer", "fruit", "number"};
            CollectionAssert.AreEqual(excepted, actual);
        }

        [Test]
        public void NormalizeWord_EmptyInput()
        {
            var testWords = new List<string>();
            var actual = sut.FilterWords(testWords);
            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void NormalizeWord_UnexistingWords()
        {
            var testWords = new List<string> {"sffwfsfsfsfsdeggrftgr", "ThisWordIsNotExist"};
            var actual = sut.FilterWords(testWords);
            CollectionAssert.IsEmpty(actual);
        }
    }
}
