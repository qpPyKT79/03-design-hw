using System.Collections.Generic;
using CloudMaker;
using CloudMaker.Extensions;
using NUnit.Framework;

namespace Tests.ExtensionsTests
{
    [TestFixture]
    public class SizeSetterTest
    {
        [Test]
        public static void SetSizeTest()
        {
            var testTags = new List<CloudTag>
            {
                new CloudTag("a").SetFrequency(32),
                new CloudTag("b").SetFrequency(64)
            };
            var actual = testTags.SetSize(1, 25);
            Assert.AreEqual(actual[0].TagSize.Width, 10, 5);
            Assert.AreEqual(actual[1].TagSize.Width, 295, 5);
        }
    }
}
