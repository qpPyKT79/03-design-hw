using System.Collections.Generic;
using CloudMaker;
using CloudMaker.Extensions;
using NUnit.Framework;

namespace Tests.ExtensionsTests
{
    [TestFixture]
    public class BoundsGetterTest
    {
        [Test]
        public static void GetBoundsTest()
        {
            var actual = new List<CloudTag>
            {
                new CloudTag("a").SetFrequency(32),
                new CloudTag("b").SetFrequency(64)
            }.SetSize(10, 25).GetBounds();
            Assert.AreEqual(actual.Item1, 395, 6);
            Assert.AreEqual(actual.Item2, 575, 6);
        }
        [Test]
        public static void GetBoundsTest_FrequenciesAndSizeNotSet()
        {
            var actual = new List<CloudTag>
            {
                new CloudTag("a"),
                new CloudTag("b")
            }.GetBounds();
            Assert.AreEqual(actual.Item1, 1, 0);
            Assert.AreEqual(actual.Item2, 1 ,0);
        }

        [Test]
        public static void GetBoundsTest_EmptyList()
        {
            var actual = new List<CloudTag>().GetBounds();
            Assert.AreEqual(actual.Item1, 0, 0);
            Assert.AreEqual(actual.Item2, 0, 0);
        }
    }
}
