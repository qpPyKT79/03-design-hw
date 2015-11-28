using System;
using System.Collections.Generic;
using CloudMaker.Filters;
using CloudMaker.SourceReaders;
using CloudMaker.Visualisations;
using CloudMaker.Writers;

namespace CloudMaker
{
    public class MainArgs
    {
        public static readonly Dictionary<string, Type> Description = new Dictionary<string, Type>
        {
            {"list", typeof(ListFileReader) },
            {"CUI", typeof (CUI)},
            {"GUI", typeof (GUI)},
            {"png", typeof (PngWriter)},
            {"jpeg", typeof (JpegWriter)},
            {"normalizer", typeof(Normalizer)},
            {"boringWords", typeof (BoringWords)}
        };
        public Type InputFileType { get; set; }
        public Type Visualisation { get; set; }
        public Type OutputFileType { get; set ; }
        public List<Type> Filters { get; set; }

        public MainArgs(string[] args)
        {
            try
            {
                InputFileType = Description[args[0]];
                Visualisation = Description[args[1]];
                OutputFileType = Description[args[2]];
                Filters = new List<Type>();
                if (args.Length >= 4) Filters.Add(Description[args[3]]);
                if (args.Length == 5) Filters.Add(Description[args[4]]);
            }
            catch (KeyNotFoundException)
            {
                IncorrectArgs("Incorrect Arguments");
                DefaultConfig();
            }
            catch (IndexOutOfRangeException)
            {
                IncorrectArgs("arguments not enough");
                DefaultConfig();
            }
        }

        private void DefaultConfig()
        {
            InputFileType = Description["list"];
            Visualisation = Description["CUI"];
            OutputFileType = Description["png"];
            Filters = new List<Type>();
        }

        private static void IncorrectArgs(string errorMsg) => Console.WriteLine($"{errorMsg} \n " +
                                                 "unput type (required): list or text \n " +
                                                 "vusialization type (required): CUI or GUI" +
                                                 "output type (required): png or jpeg" +
                                                 "filters (not required): normalizer or/and boringWords \n" +
                                                                         "setting default configuration");
    }
}
