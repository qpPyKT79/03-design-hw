using System.Drawing;
using CloudMaker;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class CloudTagTest
    {
        [Test]
        public static void CloudTag_SetFrequencyTest()
        {
            var tag = new CloudTag("TestTag");
            var actual = tag.SetFrequency(20);
            Assert.AreEqual(actual.Frequency, 20);
        }
        [Test]
        public static void CloudTag_SetSizeTest()
        {
            var tag = new CloudTag("TestTag");
            var actual = tag.SetSize(new SizeF(20,20));
            Assert.AreEqual(actual.TagSize.Height, 20);
            Assert.AreEqual(actual.TagSize.Width, 20);
        }
        [Test]
        public static void CloudTag_SetLocationTest()
        {
            var tag = new CloudTag("TestTag");
            var actual = tag.SetLocation(20, 20);
            Assert.AreEqual(actual.X, 20);
            Assert.AreEqual(actual.Y, 20);
        }
    }
}
