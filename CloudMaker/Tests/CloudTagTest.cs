using System.Drawing;
using CloudMaker;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class CloudTagTest
    {
        private CloudTag sut;
        [SetUp]
        public void SetUp() => sut = new CloudTag("TestTag");

        [Test]
        public void CloudTag_SetFrequencyTest()
        {
            var actual = sut.SetFrequency(20);
            Assert.AreEqual(actual.Frequency, 20);
        }
        [Test]
        public void CloudTag_SetSizeTest()
        {
            var actual = sut.SetSize(new SizeF(20,20));
            Assert.AreEqual(actual.TagSize.Height, 20);
            Assert.AreEqual(actual.TagSize.Width, 20);
        }
        [Test]
        public void CloudTag_SetLocationTest()
        {
            var actual = sut.SetLocation(20, 20);
            Assert.AreEqual(actual.X, 20);
            Assert.AreEqual(actual.Y, 20);
        }
    }
}
