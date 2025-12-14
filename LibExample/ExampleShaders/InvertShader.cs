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
    }
}