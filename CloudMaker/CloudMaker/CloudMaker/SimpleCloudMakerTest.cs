using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CloudMaker.CloudMaker
{
    [TestFixture]
    class SimpleCloudMakerTest :SimpleCloudMaker
    {
        [Test]
        public void CreateCloud_Test()
        {
            var cloudMaker = new SimpleCloudMaker();
            var source = new List<string> {"first", "second"};
            var actual = cloudMaker.CreateCloud(source, 1, 25, 2);
            var excepted = source.Select(word => new CloudTag(word).SetFrequency(1)).ToList().SetSize(1,25).Shuffle(2);
            CollectionAssert.AreEqual(actual,excepted);

        }
    }
}
