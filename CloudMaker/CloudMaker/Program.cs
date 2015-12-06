using System.ComponentModel.Design;
using System.Linq;
using CloudMaker.CloudMaker;
using CloudMaker.Filters;
using CloudMaker.Visualisations;
using CloudMaker.Writers;
using System.Drawing;
using System.Runtime.InteropServices;
using CloudMaker.SourceReaders;

namespace CloudMaker
{
    class Program
    {
        static void Main(string[] argv)
        {
            var options = new Options(argv);
            var inputText = new FilteringFileReader().FilterInputData(
                options.FileReaderFunc,
                options.FilterFuncs.ToArray(),
                options.VisualisationType.GetName);
            var fontSize = options.VisualisationType.GetSize();
            var cloud = new CloudMaker.CloudMaker().CreateCloud(inputText, options.VisualisationType.GetAlg(),fontSize.Item1,fontSize.Item2);
            options.WriteFunc(cloud, options.VisualisationType.GetColors);

        }

        //private void Run()
        //{
        //    var inputText = Reader.ReadWords(UI.GetName(), Filters);
        //    var size = UI.GetSize();
        //    if (inputText.Count >0)
        //        Writer.WriteTo(Maker.CreateCloud(inputText, UI.GetCloudMakerAlg(), size.Item1, size.Item2), UI.GetColors());
        //    UI.AllDone();
        //}
    }
}
