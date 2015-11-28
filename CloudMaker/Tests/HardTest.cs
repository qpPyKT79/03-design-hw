using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMaker;
using CloudMaker.Visualisations;
using FakeItEasy;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class HardTest
    {
        private ISourceReader fakeReader { get; set; }
        private ICloudMaker fakeClouder { get; set; }
        [SetUp]
        public void SetUp()
        {
            fakeReader = A.Fake<ISourceReader>();
            fakeClouder = A.Fake<ICloudMaker>();
            var temp = string.Empty;
            A.CallTo(() => fakeReader.ReadWords(temp, new IFilter[0])).Returns(new List<string>() {"a", "b"});

        }

    }
}
