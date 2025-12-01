using System.Drawing;
using ImageShading.Core;

namespace LibExample;

public class InvertShader : Fragment
{
    public override Color SetFragment(float x, float y)
    {
        const int off = 250;
        var pixel = SampleScreenBuffer(x, y);
        
        return Color.FromArgb(255, 255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
        //return Color.FromArgb(255,
        //    Math.Clamp(255 / Math.Clamp(x - 400, 1, 255) + pixel.R, 0, 255),
        //    Math.Clamp(255 / Math.Clamp(y - 400, 1, 255) + pixel.G, 0, 255),
        //    pixel.B);
    }
}