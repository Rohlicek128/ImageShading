using System.Diagnostics;
using LibExample.ExampleShaders;

namespace LibExample;

internal class Program
{
    private static void Main()
    {
        var sw = new Stopwatch();
        
        sw.Start();
        ImageShading.Core.Painter.ShadeImage("chill_guy.jpg", "shaded.png", new InvertShader());
        sw.Stop();
        Console.WriteLine($"Time: {sw.Elapsed}");
        
        ImageShading.Core.Painter.OpenImage("shaded.png");
    }
}