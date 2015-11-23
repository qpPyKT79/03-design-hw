using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper;
using NHunspell;

namespace CloudMaker.CloudMaker
{
    public class SimpleCloudMaker :ICloudMaker
    {
        public SimpleCloudMaker()
        {
        }

        private IEnumerable<CloudTag> MakeCloudTags(IEnumerable<string> source)
        {
            return source.GroupBy(word => word)
                .OrderByDescending(word => word.Count())
                .Select(words => new CloudTag(words.First()).SetFrequency(words.Count()));
            
        }

        public IEnumerable<CloudTag> CreateCloud(IEnumerable<string> source, int minSize = 1, int maxSize = 24)
        {
            var tags = MakeCloudTags(source).ToList();
            tags = SetSize(tags).ToList();
            tags = Shuffle(tags).ToList();
            return SetLocatons(tags);
        }
        public static IEnumerable<CloudTag> Shuffle(IEnumerable<CloudTag> tags)
        {
            Random rnd = new Random();
            return tags.OrderBy((item) => rnd.Next());
        }

        private static CloudTag SetLocation(Canvas canv, CloudTag tag)
        {
            var x = 0;
            var y = 0;
            var z = 0;
            canv.AddRectangle((int)tag.TagSize.Width, (int)tag.TagSize.Height, out x, out y, out z);
            return tag.SetLocation(x+1, y+1);
        }

        private static IEnumerable<CloudTag> SetLocatons(IEnumerable<CloudTag> tags)
        {
            var canvas = new Canvas();
            var square = (int) tags.Sum(tag => tag.TagSize.Width)*(int) tags.Sum(tag => tag.TagSize.Height)*100;
            canvas.SetCanvasDimensions(square,square);
            return tags.Select(tag => SetLocation(canvas, tag)).ToList();
        }
   
        private static IEnumerable<CloudTag> SetSize(IEnumerable<CloudTag> tags)
        {
            var newTags = new List<CloudTag>();
            using (Image tempImage = new Bitmap(100,100))
            using (var g = Graphics.FromImage(tempImage))
                foreach (var tag in tags)
                    newTags.Add(tag.SetSize(g.MeasureString(tag.Word, new Font("Times New Roman", tag.Frequency*10))));
            return newTags;
                //return tags.Select(
                //    tag => tag.SetSize(g.MeasureString(tag.Word, new Font("Times New Roman", tag.Frequency))));
        }
    }
}
