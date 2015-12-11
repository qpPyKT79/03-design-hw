using System.Collections.Generic;
using NUnit.Framework;

namespace CloudMaker.SourceReaders
{
    [TestFixture]
    public class ListFileReaderTest
    {
        private ListFileReader reader;

        [SetUp]
        public void SetUp() => reader = new ListFileReader();

        [Test]
        public void ReadFromFileTest()
        {
            var actual = reader.ReadFromFile("Test.txt");
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
        public void ReadFromFileTest_UnexistableFile()
            => CollectionAssert.IsEmpty(reader.ReadFromFile("UnexistbleFile.UnexistableExtension"));
    }
}
