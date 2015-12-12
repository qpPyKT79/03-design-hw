﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CloudMaker.Extensions
{
    public static class SizeSetter
    {
        public static List<CloudTag> SetSize(this List<CloudTag> tags, int minSize, int maxSize)
        {
            if (tags.Count == 0)
                return tags;
            int maxFreq = (int)tags.Max(tag => tag.Frequency);
            int minFreq = (int)tags.Min(tag => tag.Frequency);
            var newTags = new List<CloudTag>();
            using (Image tempImage = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(tempImage))
                foreach (var tag in tags)
                    newTags.Add(SetSize(tag, g, minSize, maxSize, minFreq, maxFreq));
            return newTags;
        }

        private static CloudTag SetSize(CloudTag tag, Graphics img, int minSize, int maxSize, int minFreq, int maxFreq)
        {
            var size = tag.Frequency > minFreq ? (maxSize * (tag.Frequency - minFreq)) / (maxFreq - minFreq) + minSize : minSize;
            size *= 10;
            return tag.SetSize(img.MeasureString(tag.Word,
                new Font("Times New Roman", size))).SetFrequency(size);
        }
    }
}
