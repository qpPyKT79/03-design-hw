using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Nuclex.Game.Packing;

namespace CloudMaker.CloudMaker
{
    public class SimpleCloudMaker :ICloudMaker
    {
        private int Width { get; set; }
        private int Height { get; set; }
        public SimpleCloudMaker()
        {
            Width = 0;
            Height = 0;
        }

        public List<CloudTag> CreateCloud(List<string> source, int minSize, int maxSize)
        {
            var tags = MakeCloudTags(source);
            tags = SetSize(tags);
            tags = Shuffle(tags);
            return SetLocatons(tags);
        }

        private List<CloudTag> SetSize(List<CloudTag> tags)
        {
            var newTags = new List<CloudTag>();
            using (Image tempImage = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(tempImage))
                foreach (var tag in tags)
                    newTags.Add(tag.SetSize(g.MeasureString(tag.Word, new Font("Times New Roman",((float)(Math.Log(tag.Frequency,2)+1)*10)))));
            return newTags;
        }

        private static List<CloudTag> Shuffle(List<CloudTag> tags)
        {
            Random rnd = new Random();
            return tags.OrderBy((item) => rnd.Next()).ToList();
        }

        private List<CloudTag> MakeCloudTags(List<string> source) => source.GroupBy(word => word)
            .OrderByDescending(word => word.Count())
            .Select(words => new CloudTag(words.First()).SetFrequency(words.Count())).ToList();
        
        private List<CloudTag> SetLocatons(List<CloudTag> tags)
        {
            foreach (var tag in tags)
            {
                Width += (int)tag.TagSize.Width+1;
                Height += (int)tag.TagSize.Height + 1;
            }
            ArevaloRectanglePacker packer = new ArevaloRectanglePacker(Width, Height);
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

