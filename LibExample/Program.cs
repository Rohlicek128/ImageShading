using LibExample.ExampleShaders;

namespace LibExample;

internal class Program
{
    private static void Main()
    {
        ImageShading.Core.Painter.ShadeImage("chill_guy.jpg", "shaded.png", new TestingShader());
        ImageShading.Core.Painter.OpenImage("shaded.png");
    }
}