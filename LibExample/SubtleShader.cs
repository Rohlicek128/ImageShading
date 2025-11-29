using System.Drawing;
using ImageShading.Core;

namespace LibExample;

public class SubtleShader : Fragment
{
    public override Color SetFragment(int x, int y)
    {
        return SampleScreenBuffer(x + 968 / 2, y);
    }
}