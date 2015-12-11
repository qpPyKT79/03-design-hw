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
    }
}
