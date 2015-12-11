using System;
using System.Collections.Generic;
using System.Linq;
using CloudMaker.SourceReaders;
using NUnit.Framework;

namespace Tests.ReaderTests
{
    [TestFixture]
    public class FiltersTest
    {
        private List<string> inputData; 
        private List<Func<List<string>, List<string>>> filters;
        private Filter filter;

        [SetUp]
        public void SetUp()
        {
            inputData = new List<string> {"UnexistableWord", "the", "doors", "simple"};
            filter = new Filter();
            filters = new List<Func<List<string>, List<string>>>
            {
                words => words.Select(word => word+"1").ToList()
            };
        }

        [Test]
        public void FilterDataTest()
        {
            var actual = filter.ReadAndFilterInputData(filename => inputData, filters, string.Empty);
            var excepted = new List<string> {"UnexistableWord1", "the1", "doors1", "simple1" };
            CollectionAssert.AreEqual(excepted, actual);
        } 
    }
}
