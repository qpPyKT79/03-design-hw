using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuclex.Game.Packing;

namespace CloudMaker
{
    public static class Extensions
    {
        public static List<CloudTag> SetSize(this List<CloudTag> tags)
        {
            var newTags = new List<CloudTag>();
            using (Image tempImage = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(tempImage))
                foreach (var tag in tags)
                    newTags.Add(
                        tag.SetSize(g.MeasureString(tag.Word,
                            new Font("Times New Roman", ((float)(Math.Log(tag.Frequency, 2) + 1) * 10)))));
            return newTags;
        }

        public static List<CloudTag> Shuffle(this List<CloudTag> tags)
        {
            Random rnd = new Random();
            return tags.OrderBy(item => rnd.Next()).ToList();
        }

        public static List<CloudTag> SetLocatons(this List<CloudTag> tags)
        {
            var width = 0;
            var height = 0;
            foreach (var tag in tags)
            {
                width += (int)tag.TagSize.Width + 1;
                height += (int)tag.TagSize.Height + 1;
            }
            ArevaloRectanglePacker packer = new ArevaloRectanglePacker(width, height);
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
