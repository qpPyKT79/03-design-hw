using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using CloudMaker.Filters;
using CloudMaker.Interfaces;
using CloudMaker.SourceReaders;
using CloudMaker.Visualisations;
using CloudMaker.Writers;

namespace CloudMaker
{
    public class Options
    {
        public static readonly Dictionary<string, Func<Func<string>, List<string>>> ReadFileMethod = new Dictionary
            <string, Func<Func<string>, List<string>>>
        {
            {"list", (getSourceName) => new FileReader().ReadFromFile(getSourceName)}
        };
        public static readonly Dictionary<string, Settings> UiType = new Dictionary<string, Settings>
        {
            {"CUI", new CUI().GetSettings()},
            {"GUI", new GUI().GetSettings()}
        };

        public static readonly Dictionary<string, Action<List<CloudTag>, Func<Color[]>>> WriterType = new Dictionary
            <string, Action<List<CloudTag>, Func<Color[]>>>
        {
            {"png", (tags, colors) => new ImageWriter().WriteTo(tags, colors, ImageFormat.Png)},
            {"jpeg", (tags, colors) => new ImageWriter().WriteTo(tags, colors, ImageFormat.Jpeg)}
        };

        public static readonly Dictionary<string, Func<List<string>, List<string>>> FilterTypes = new Dictionary
            <string, Func<List<string>, List<string>>>
        {
             {"normalizer", (words) => new Normalizer().FilterWords(words)},
             {"boringWords", (words) => new BoringWordsFilter().FilterWords(words)}
        };
        
        public Func<Func<string>, List<string>> FileReaderFunc { get;}
        public Settings VisualisationType { get;}
        public Action<List<CloudTag>, Func<Color[]>> WriteFunc { get;}
        public List<Func<List<string>, List<string>>> FilterFuncs { get; }
        //public List<Type> FilterTypes { get; set; }

        public Options(string[] args)
        {
            VisualisationType = UiType["CUI"];
            FileReaderFunc = ReadFileMethod["list"];
            WriteFunc = WriterType["png"];
            FilterFuncs = new List<Func<List<string>, List<string>>>();
            try
            {
                VisualisationType = UiType[args[0]];
                WriteFunc = WriterType[args[2]];
                FileReaderFunc = ReadFileMethod[args[1]];
                if (args.Length >= 4) FilterFuncs.Add(FilterTypes[args[3]]);
                if (args.Length == 5) FilterFuncs.Add(FilterTypes[args[4]]);
            }
            catch (KeyNotFoundException)
            {
                PrintArgsError("Incorrect Arguments");
            }
            catch (IndexOutOfRangeException)
            {
                PrintArgsError("arguments not enough");
            }
        }

        private static void PrintArgsError (string errorMsg) => Console.WriteLine($"{errorMsg} \n " +
                                                   "unput type (required): list or text \n " +
                                                   "vusialization type (required): CUI or GUI" +
                                                   "output type (required): png or jpeg" +
                                                   "filters (not required): normalizer or/and boringWords \n" +
                                                   "setting default configuration");
    }
}