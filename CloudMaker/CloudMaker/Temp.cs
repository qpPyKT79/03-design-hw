using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CloudMaker
{
    public static class Temp
    {
        

        

        public static List<CloudTag> Shuffle(this List<CloudTag> tags)
        {
            var rnd = new Random();
            return tags.OrderBy(item => rnd.Next()).ToList();
        }

        
    }
}
