using CloudMaker.SourceReaders;

namespace CloudMaker
{
    class Program
    {
        static void Main(string[] argv)
        {
            var options = new Options(argv);
            var uiSettings = options.VisualisationType();
            var inputText = new FilteringFileReader().FilterInputData(
                options.FileReaderFunc,
                options.FilterFuncs.ToArray(),
                uiSettings.Filename);
            var fontSize = uiSettings.FontSize;
            var cloud = new CloudMaker.CloudMaker().CreateCloud(inputText, uiSettings.Alg, fontSize.Item1, fontSize.Item2);
            options.WriteFunc(cloud, uiSettings.Colors);

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
