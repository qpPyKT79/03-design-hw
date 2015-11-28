using System.Drawing;
using CloudMaker.Visualisations;

namespace CloudMaker
{
    public interface IVisulisation
    {
        IVisulisation GetCloudMakerAlg(out AlgName cloudMakerAlg);
        IVisulisation GetName(out string sourceName);
        IVisulisation GetSize(out int minSize, out int maxSize);
        IVisulisation GetColors(out Color[] colors);
        IVisulisation AllDone();
    }
}
