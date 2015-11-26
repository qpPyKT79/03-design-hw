using System.Collections.Generic;
using System.Linq;

namespace CloudMaker.CloudMaker
{
    public class SimpleCloudMaker :ICloudMaker
    {
        public SimpleCloudMaker()
        {
        }        

        public List<CloudTag> CreateCloud(List<string> source, int minSize, int maxSize) => 
            MakeCloudTags(source).SetSize(minSize, maxSize).Shuffle().SetLocatons();

        private static List<CloudTag> MakeCloudTags(List<string> source) => source.GroupBy(word => word)
            .OrderByDescending(word => word.Count())
            .Select(words => new CloudTag(words.First()).SetFrequency(words.Count())).ToList();

    }
}

