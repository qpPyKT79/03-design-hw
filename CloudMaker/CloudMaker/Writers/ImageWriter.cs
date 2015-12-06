using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace CloudMaker.Writers
{
    public class ImageWriter
    {
        public void WriteTo(List<CloudTag> tags, Func<Color[]> getColors, ImageFormat format)
        {
            string outputSourceName = "out.png";
            float width;
            float height;
            var colors = getColors();
            tags.GetBounds(out width, out height);
            var random = new Random();
            using (var image = new Bitmap((int)width+1, (int)height+1))
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
