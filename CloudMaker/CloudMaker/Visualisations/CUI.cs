using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CloudMaker.Visualisations
{
    public class CUI
    {
        private static readonly HashSet<string> Algs = new HashSet<string> {"arevalo", "simple"} ;
        public AlgName GetCloudMakerAlg()
        {
            AlgName cloudMakerAlg;
            Console.WriteLine();
            Console.WriteLine("Set algorithm of making cloud, members are:");
            Console.WriteLine(string.Join(" ", Algs));
            Console.WriteLine("if u dont want to set up this field. just set an empty string");
            var inputString = Console.ReadLine();
            Enum.TryParse(inputString, out cloudMakerAlg);
            return cloudMakerAlg;
        }

        public string GetName()
        {
            Console.WriteLine("Plese type Filename");
            return Console.ReadLine();
        }

        public Tuple<int,int> GetSize()
        {
            var minSize = 5;
            var maxSize = 25;
            Console.WriteLine();
            Console.WriteLine("Font size is not set or minSize > maxSize");
            Console.WriteLine("Note! minSIze must be >= 5 and maxSize <= 25");
            Console.WriteLine("Write u min and max size separated with whitespace");
            Console.WriteLine();
            Console.WriteLine("if u dont want to set up font size, just set an empty string");
            var sizeString = Console.ReadLine();
            var sizeNums = string.IsNullOrEmpty(sizeString) ? null : sizeString.Split(' ').Select(int.Parse).ToArray();
            if (sizeNums?.Length<2)
                GetSize();
            else
            {
                if (sizeNums == null)
                    return new Tuple<int, int>(5,25);
                minSize = sizeNums[0];
                maxSize = sizeNums[1];
            }
            return minSize>=5 && maxSize<= 25 && minSize!=maxSize? new Tuple<int, int>(minSize,maxSize) : GetSize();
        }

        public Color[] GetColors()
        {
            Console.WriteLine();
            Console.WriteLine("Write colors separated with whitespase (if u dont want to set up colors, just set an empty string)");
            var stringColors = Console.ReadLine();
            return string.IsNullOrWhiteSpace(stringColors) ? null: stringColors.Split(' ').Select(Color.FromName).ToArray();
        }

        public Settings GetSettings() => new Settings(GetName(), GetCloudMakerAlg(), GetSize(), GetColors());
        
    }
}
