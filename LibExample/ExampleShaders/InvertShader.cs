using ImageShading.Core;
using ImageShading.Math;

namespace LibExample.ExampleShaders;

public class InvertShader : Fragment
{
    public override Vec4 SetFragment(Vec2 coordinates)
    {
        //const int off = 250;
        var pixel = SampleScreenBuffer(coordinates);
        
        return new Vec4(1f - pixel.X, 1f - pixel.Y, 1f - pixel.Z, 1f);
        //return Color.FromArgb(255,
        //    Math.Clamp(255 / Math.Clamp(x - 400, 1, 255) + pixel.R, 0, 255),
        //    Math.Clamp(255 / Math.Clamp(y - 400, 1, 255) + pixel.G, 0, 255),
        //    pixel.B);
    }
}