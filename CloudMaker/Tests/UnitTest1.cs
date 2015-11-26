using System;
using System.Drawing;
using CloudMaker;
using nunit.framework;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tag = new CloudTag("wat");
            tag.SetFrequency(4);
            SizeF a;
            using (Image tempImage = new Bitmap(100, 100))
            using (var g = Graphics.FromImage(tempImage))
                a = g.MeasureString("ololo", new Font("Times New Roman", 16));
            Assert.AreEqual(a, null);
        }
    }
}
