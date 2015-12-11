﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using CloudMaker.Extensions;

namespace CloudMaker.Writers
{
    public class ImageWriter
    {
        public void WriteTo(List<CloudTag> tags, Color[] colors, ImageFormat format)
        {
            string outputSourceName = "out.png";
            var bounds = tags.GetBounds();
            var random = new Random();
            using (var image = new Bitmap((int)bounds.Item1+1, (int)bounds.Item2+1))
            using (var g = Graphics.FromImage(image))
            {
                foreach (var tag in tags)
                    g.DrawString(tag.Word, new Font("Times New Roman", tag.Frequency),
                        new SolidBrush(GetRandomColor(random, colors)), tag.X, tag.Y);
                image.Save(outputSourceName, format);
            }
        }
        
        private static Color GetRandomColor(Random random, Color[] colors) => 
            colors?[random.Next()%colors.Length] ?? Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
    }
}
