using System;
using System.Collections.Generic;
using System.Linq;
using Nuclex.Game.Packing;

namespace CloudMaker.CloudMaker
{
    public class SimpleCloudMaker :ICloudMaker
    {
        private static readonly Dictionary<string, Func<int, int, RectanglePacker>> packers = new Dictionary<string, Func<int, int, RectanglePacker>>
        {
            {"simple", (width, height) => new SimpleRectanglePacker(width, height) },
            {"arevalo", (width, height) => new ArevaloRectanglePacker(width, height) }
        };  
        public List<CloudTag> CreateCloud(List<string> source, string packerAlgorithm, int minSize, int maxSize) =>
            SetLocatons(source.SetFrequences().SetSize(minSize, maxSize), packerAlgorithm).Shuffle();

        private static List<CloudTag> SetLocatons(List<CloudTag> tags, string packerAlgorithm)
        {
            float maxWidth = tags.Max(tag => tag.TagSize.Width);
            maxWidth = (float)tags.Count * maxWidth;
            var packer = packers[packerAlgorithm]((int)maxWidth, (int)maxWidth);
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

