using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker.Filters;
using CloudMaker.Readers;
using NUnit.Framework;

namespace CloudMaker.SourceReaders
{
    [TestFixture]
    class ListFileReaderTest : ListFileReader
    {
        [Test]
        public static void ReadFromFileTest()
        {
            var actual = ListFileReader.GetTextFromFile("Test.txt");
            var excepted = new List<string>
            {
                "this",
                "is",
                "test",
                "file",
                "unexistableword",
                "here",
                "some",
                "boring",
                "words",
                "the",
                "of",
                "as",
                "and",
                "not",
                "normilized",
                "words",
                "playing"
            };
            CollectionAssert.AreEqual(excepted, actual);
        }
        [Test]
        public static void ReadFromFileTest_UnexistableFile()
        {
            var actual = ListFileReader.GetTextFromFile("UnexistbleFile.UnexistableExtension");
            var excepted = new List<string>();
            CollectionAssert.AreEqual(excepted, actual);
        }
        [Test]
        public static void ReaderTest_WithFilters()
        {
            var reader = new ListFileReader();
            var actual = reader.ReadWords("Test.txt", new IFilter[]{new Normalizer(), new BoringWords()});
            var excepted = new List<string>
            {
                "this",
                "be",
                "test",
                "file",
                "here",
                "some",
                "boring",
                "word",
                "not",
                "word",
                "playing"
            };
            CollectionAssert.AreEqual(excepted, actual);
        }
    }
}
