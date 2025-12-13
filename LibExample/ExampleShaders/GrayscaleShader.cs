using ImageShading.Core;
using ImageShading.Math;

namespace LibExample.ExampleShaders;

public class GrayscaleShader : Fragment
{
    public override Vec4 SetFragment(Vec2 coordinates)
    {
        var pixel = SampleScreenBuffer(coordinates) * new Vec4(0.299f, 0.587f, 0.114f, 1f);
        return new Vec4(new Vec3(pixel.R + pixel.G + pixel.B), 1f);
    }
}