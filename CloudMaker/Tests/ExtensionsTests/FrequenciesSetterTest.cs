using System.Collections.Generic;
using CloudMaker;
using CloudMaker.Extensions;
using NUnit.Framework;

namespace Tests.ExtensionsTests
{
    [TestFixture]
    public class FrequenciesSetterTest
    {
        [Test]
        public static void SetFrequenciesTest()
        {
            var actual = new List<string>
            {"a","a","a","a","a","a","a","a","a","a","a","a","a","a","a","a",
            "b","b","b","b","b","b","b","b",
            "c","c","c","c"}.SetFrequences();
            var excepted = new List<CloudTag>
            {
                new CloudTag("a").SetFrequency(16),
                new CloudTag("b").SetFrequency(8),
                new CloudTag("c").SetFrequency(4)
            };
            CollectionAssert.AreEqual(actual, excepted);
        }

        [Test]
        public static void SetFrequenciesTest_EmptyList()=>
            CollectionAssert.IsEmpty(new List<string>().SetFrequences());
    }
}
