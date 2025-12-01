using System.Drawing;
using ImageShading.Core;

namespace LibExample;

public class SubtleShader : Fragment
{
    public override Color SetFragment(float x, float y)
    {
        var pixel = SampleScreenBuffer(x, y);
        return Color.FromArgb(255, pixel.R, 0, 0);
    }
}