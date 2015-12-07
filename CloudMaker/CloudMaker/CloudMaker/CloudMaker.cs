﻿using System;
using System.Collections.Generic;
using System.Linq;
using CloudMaker.Visualisations;
using Microsoft.Xna.Framework;
using Nuclex.Game.Packing;

namespace CloudMaker.CloudMaker
{
    public class CloudMaker
    {
        private static readonly Dictionary<AlgName, Func<int, int, RectanglePacker>> packers = new Dictionary<AlgName, Func<int, int, RectanglePacker>>
        {
            {AlgName.simple, (width, height) => new SimpleRectanglePacker(width, height) },
            {AlgName.arevalo, (width, height) => new ArevaloRectanglePacker(width, height) }
        };
          
        public List<CloudTag> CreateCloud(List<string> source, AlgName packerAlgorithm, int minSize, int maxSize) =>
            SetLocatons(source.SetFrequences().SetSize(minSize, maxSize), packerAlgorithm).Shuffle();

        private List<CloudTag> SetLocatons(List<CloudTag> tags, AlgName packerAlgorithm)
        {
            var maxWidth = getMaxWidth(tags);
            var packer = packers[packerAlgorithm]((int)maxWidth, (int)maxWidth);
            Point placement;
            return tags.Select(tag =>
            {
                placement = packer.Pack((int) tag.TagSize.Width, (int) tag.TagSize.Height);
                return tag.SetLocation(placement.X, placement.Y);
            }).ToList();
        }

        public float getMaxWidth(List<CloudTag> tags) => (float)Math.Log(tags.Count, 2) * tags.Max(tag => tag.TagSize.Width);
    }
}

