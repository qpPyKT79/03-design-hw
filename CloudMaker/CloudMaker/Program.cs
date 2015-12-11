using CloudMaker.SourceReaders;

namespace CloudMaker
{
    public class Program
    {
        static void Main(string[] argv)
        {
            var options = new Options(argv);
            var uiSettings = options.VisualisationType;
            var inputText = new FilterInputData().ReadAndFilterInputData(
                options.FileReaderFunc,
                options.FilterFuncs,
                uiSettings.Filename);
            var cloud = new CloudMaker.CloudMaker().CreateCloud(inputText, uiSettings.CloudOptions);
            options.WriteFunc(cloud, uiSettings.Colors);

        }
    }
}
