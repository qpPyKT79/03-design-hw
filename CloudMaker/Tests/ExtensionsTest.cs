﻿using System.Collections.Generic;
using CloudMaker;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class ExtensionsTest
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
            Assert.AreEqual(actual[0].TagSize.Width,10,5);
            Assert.AreEqual(actual[1].TagSize.Width, 295, 5);
        }
        [Test]
        public static void GetBoundsTest()
        {
            float width;
            float height;
            var some = new List<CloudTag>
            {
                new CloudTag("a").SetFrequency(32),
                new CloudTag("b").SetFrequency(64)
            }.SetSize(10, 25).GetBounds(out width, out height);
            Assert.AreEqual(width, 395, 6);
            Assert.AreEqual(height, 575, 6);
        }
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
            CollectionAssert.AreEqual(actual,excepted);
        }
    }
}
