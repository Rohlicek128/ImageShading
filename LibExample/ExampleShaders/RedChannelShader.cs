using ImageShading.Core;
using ImageShading.Math;

namespace LibExample.ExampleShaders;

public class RedChannelShader : Fragment
{
    public override Vec4 SetFragment(Vec2 coordinates)
    {
        var pixel = SampleScreenBuffer(coordinates);
        return new Vec4(pixel.R, 0, 0, 1f);
    }
}