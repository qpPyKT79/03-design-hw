using System;
using System.Collections.Generic;
using System.Linq;
using CloudMaker.Visualisations;
using Nuclex.Game.Packing;

namespace CloudMaker.CloudMaker
{
    public class SimpleCloudMaker :ICloudMaker
    {
        private static readonly Dictionary<AlgName, Func<int, int, RectanglePacker>> packers = new Dictionary<AlgName, Func<int, int, RectanglePacker>>
        {
            {AlgName.simple, (width, height) => new SimpleRectanglePacker(width, height) },
            {AlgName.arevalo, (width, height) => new ArevaloRectanglePacker(width, height) }
        };  
        public List<CloudTag> CreateCloud(List<string> source, AlgName packerAlgorithm, int minSize, int maxSize) =>
            SetLocatons(source.SetFrequences().SetSize(minSize, maxSize), packerAlgorithm).Shuffle();

        private static List<CloudTag> SetLocatons(List<CloudTag> tags, AlgName packerAlgorithm)
        {
            float maxWidth = tags.Max(tag => tag.TagSize.Width);
            maxWidth =(float) Math.Log(tags.Count,2) * maxWidth;
            var packer = packers[packerAlgorithm]((int)maxWidth, (int)maxWidth);
            Microsoft.Xna.Framework.Point placement;
            return tags.Select(tag =>
            {
                placement = packer.Pack((int) tag.TagSize.Width, (int) tag.TagSize.Height);
                return tag.SetLocation(placement.X, placement.Y);
            }).ToList();
        }
    }
}

