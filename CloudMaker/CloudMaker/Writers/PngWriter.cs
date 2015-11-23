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
            using (var image = new Bitmap((int)tags.Sum(tag => tag.TagSize.Width), (int)tags.Sum(tag => tag.TagSize.Height)))
            using (var g = Graphics.FromImage(image))
            {
                foreach (var tag in tags)
                {
                    var color = GetRandomColor();
                    g.DrawString(tag.Word, new Font("Times New Roman", tag.Frequency*10),
                        new SolidBrush(color), tag.X, tag.Y);
                }
                image.Save(outputSourceName, ImageFormat.Png);
            }
        }
        private static Color GetRandomColor()
        {
            var random = new Random();
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
