﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CloudMaker
{
    public static class Extensions
    {
        public static List<CloudTag> SetSize(this List<CloudTag> tags, int minSize, int maxSize)
        {
            int maxFreq = (int) tags.Max(tag => tag.Frequency);
            int minFreq = (int) tags.Min(tag => tag.Frequency);
            var newTags = new List<CloudTag>();
            using (Image tempImage = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(tempImage))
                foreach (var tag in tags)
                    newTags.Add(SetSize(tag, g, minSize, maxSize, minFreq, maxFreq));
            return newTags;
        }

        private static CloudTag SetSize(CloudTag tag, Graphics img, int minSize, int maxSize, int minFreq, int maxFreq)
        {
            var size = tag.Frequency>minFreq? (maxSize*(tag.Frequency-minFreq))/(maxFreq-minFreq)+minSize:minSize;
            size *= 10;
            return tag.SetSize(img.MeasureString(tag.Word,
                new Font("Times New Roman", size))).SetFrequency(size);
        }

        public static List<CloudTag> GetBounds(this List<CloudTag> tags, out float width, out float height)
        {
            width = 0;
            height = 0;
            foreach (var tag in tags)
            {
                if (width <= tag.X + tag.TagSize.Width)
                    width = tag.X + (int)tag.TagSize.Width + 1;
                if (height <= tag.Y + tag.TagSize.Height)
                    height = tag.Y + (int)tag.TagSize.Height + 1;
            }
            return tags;
        }

        public static List<CloudTag> Shuffle(this List<CloudTag> tags)
        {
            var rnd = new Random();
            return tags.OrderBy(item => rnd.Next()).ToList();
        }

        public static List<CloudTag> SetFrequences(this List<string> source) => source.GroupBy(word => word)
            .OrderByDescending(word => word.Count())
            .Select(words => new CloudTag(words.First()).SetFrequency(words.Count())).Take(100).ToList();
    }
}
