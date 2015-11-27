using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CloudMaker.Filters
{
    [TestFixture]
    class NormalizerTest
    {
        [Test]
        public static void NormalizeWordTest()
        {
            var testWords = new List<string> { "counting","thinks" };
            var filter = new Normalizer();
            var actual = filter.FilterWords(testWords);
            var excepted = new List<string> {"count","think"};
            CollectionAssert.AreEqual(excepted, actual);
        }
        [Test]
        public static void NormalizeWord_NothingNormilize()
        {
            var testWords = new List<string> {"computer", "fruit", "number" };
            var filter = new Normalizer();
            var actual = filter.FilterWords(testWords);
            var excepted = new List<string> { "computer", "fruit", "number"};
            CollectionAssert.AreEqual(excepted, actual);
        }

        [Test]
        public static void NormalizeWord_EmptyInput()
        {
            var testWords = new List<string>();
            var filter = new Normalizer();
            var actual = filter.FilterWords(testWords);
            var excepted = new List<string>();
            CollectionAssert.AreEqual(excepted, actual);
        }
        [Test]
        public static void NormalizeWord_UnexistingWords()
        {
            var testWords = new List<string> {"sffwfsfsfsfsdeggrftgr", "ThisWordIsNotExist"};
            var filter = new Normalizer();
            var actual = filter.FilterWords(testWords);
            var excepted = new List<string>();
            CollectionAssert.AreEqual(excepted, actual);
        }
    }
}
