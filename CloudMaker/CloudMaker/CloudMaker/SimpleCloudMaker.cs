using System.Collections.Generic;
using System.Linq;

namespace CloudMaker.CloudMaker
{
    public class SimpleCloudMaker :ICloudMaker
    {
        public List<CloudTag> CreateCloud(List<string> source, int minSize, int maxSize) => 
            source.SetFrequences().SetSize(minSize, maxSize).SetLocatons().Shuffle();
        public List<CloudTag> CreateCloud(List<string> source, int minSize, int maxSize, int seed) =>
            source.SetFrequences().SetSize(minSize, maxSize).SetLocatons().Shuffle(seed);
    }
}

