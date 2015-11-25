using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Writers
{
    class PngWriter :IWriter
    {
        public PngWriter()
        {
            
        }
        public void WriteTo(IEnumerable<CloudTag> tags, string outputSourceName)
        {
            float width = 0;
            float height = 0;
            foreach (var tag in tags)
            {
                width += tag.TagSize.Width;
                height += tag.TagSize.Height;
            }
            var random = new Random();
            using (var image = new Bitmap((int)width, (int)height))
            using (var g = Graphics.FromImage(image))
            {
                foreach (var tag in tags)
                    g.DrawString(tag.Word, new Font("Times New Roman", ((float)(Math.Log(tag.Frequency, 2) +1) * 10)),
                        new SolidBrush(GetRandomColor(random)), tag.X, tag.Y);
                image.Save(outputSourceName, ImageFormat.Png);
            }
        }
        private static Color GetRandomColor(Random random)=> Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        
    }
}
