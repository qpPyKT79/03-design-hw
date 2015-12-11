using System.Collections.Generic;
using CloudMaker.SourceReaders;
using NUnit.Framework;

namespace Tests.ReaderTests
{
    [TestFixture]
    public class TextFileReaderTest
    {
        private TextFileReader reader;

        [SetUp]
        public void SetUp() => reader = new TextFileReader();

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
