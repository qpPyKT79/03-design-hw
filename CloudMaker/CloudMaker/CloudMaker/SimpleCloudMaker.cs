using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Nuclex.Game.Packing;

namespace CloudMaker.CloudMaker
{
    public class SimpleCloudMaker :ICloudMaker
    {
        public SimpleCloudMaker()
        {
        }
        

        public List<CloudTag> CreateCloud(List<string> source, int minSize, int maxSize) => 
            MakeCloudTags(source).SetSize().Shuffle().SetLocatons();


        

        private static List<CloudTag> MakeCloudTags(List<string> source) => source.GroupBy(word => word)
            .OrderByDescending(word => word.Count())
            .Select(words => new CloudTag(words.First()).SetFrequency(words.Count())).ToList();
        
        
        


    }
}

