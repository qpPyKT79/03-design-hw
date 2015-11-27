using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CloudMaker.Filters
{
    [TestFixture]
    public class BoringWordsTest
    {
        [Test]
        public static void FilterWordsTest_AllBoring()
        {
            var testWords = new List<string> {"of", "as", "the", "versus"};
            var filter = new BoringWords();
            var actual = filter.FilterWords(testWords);
            var excepted = new List<string>();
            CollectionAssert.AreEqual(excepted,actual);
        }
        [Test]
        public static void FilterWordsTest_EmptyInput()
        {
            var testWords = new List<string>();
            var filter = new BoringWords();
            var actual = filter.FilterWords(testWords);
            var excepted = new List<string>();
            CollectionAssert.AreEqual(excepted, actual);
        }
        [Test]
        public static void FilterWordsTest_FiltringNothing()
        {
            var testWords = new List<string> { "NotBoringWord", "NotBoringWordToo" };
            var filter = new BoringWords();
            var actual = filter.FilterWords(testWords);
            var excepted = new List<string> { "NotBoringWord", "NotBoringWordToo" };
            CollectionAssert.AreEqual(excepted, actual);
        }
    }
}
