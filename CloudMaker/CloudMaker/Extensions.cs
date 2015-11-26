using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Nuclex.Game.Packing;

namespace CloudMaker
{
    public static class Extensions
    {
        public static List<CloudTag> SetSize(this List<CloudTag> tags, int minSize, int maxSize)
        {
            var newTags = new List<CloudTag>();
            using (Image tempImage = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(tempImage))
                foreach (var tag in tags)
                {
                    var size = (float)(Math.Log(tag.Frequency, 2) + 1);
                    size = size > maxSize ? maxSize : (size < minSize ? minSize : size);
                    size *= 10;
                    newTags.Add(tag.SetSize(g.MeasureString(tag.Word,
                        new Font("Times New Roman", size))).SetFrequency(size));
                }
            return newTags;
        }

        public static List<CloudTag> Shuffle(this List<CloudTag> tags)
        {
            Random rnd = new Random();
            return tags.OrderBy(item => rnd.Next()).ToList();
        }

        public static List<CloudTag> SetLocatons(this List<CloudTag> tags)
        {
            float maxWidth = tags.Max(tag => tag.TagSize.Width);
            maxWidth = ((float)Math.Log(tags.Count, 2) + 1)*maxWidth;
            ArevaloRectanglePacker packer = new ArevaloRectanglePacker((int)maxWidth, (int)maxWidth);
            for (var i = 0; i < tags.Count; i++)
            {
                Microsoft.Xna.Framework.Point placement;
                packer.TryPack((int)tags[i].TagSize.Width, (int)tags[i].TagSize.Height, out placement);
                tags[i] = tags[i].SetLocation(placement.X, placement.Y);
            }
            return tags;
        }
    }
}
