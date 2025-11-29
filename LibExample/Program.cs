using System.Diagnostics;

namespace LibExample;

internal class Program
{
    private static void Main()
    {
        //ImageShading.Core.Painter.PaintPng("test.png", Color.Yellow, 420);
        
        var sw = new Stopwatch();
        
        sw.Start();
        ImageShading.Core.Painter.ShadeImage("chill_guy.jpg", "shaded.png", new SubtleShader());
        sw.Stop();
        Console.WriteLine($"Time: {sw.Elapsed}");
    }
}