using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Writers
{
    class PngWriter :IWriter
    {
        public void WriteTo(List<CloudTag> tags, Color[] colors = null)
        {
            string outputSourceName = "out.png";
            float width;
            float height;
            tags.GetBounds(out width, out height);
            var random = new Random();
            using (var image = new Bitmap((int)width+1, (int)width+1))
            using (var g = Graphics.FromImage(image))
            {
                foreach (var tag in tags)
                    g.DrawString(tag.Word, new Font("Times New Roman", tag.Frequency),
                        new SolidBrush(GetRandomColor(random, colors)), tag.X, tag.Y);
                image.Save(outputSourceName, ImageFormat.Png);
            }
        }
        
        private static Color GetRandomColor(Random random, Color[] colors) => 
            colors?[random.Next()%colors.Length] ?? Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
    }
}
