using System.Drawing;
using System.Drawing.Imaging;

namespace ImageShading.Core;

public static class Painter
{
    public static void PaintPng(string path, Color color, int width)
    {
        using var b = new Bitmap(width, width);
        using var g = Graphics.FromImage(b);
        
        g.Clear(color);
        
        b.Save(path, ImageFormat.Png);
    }

    public static void EditPng(string inPath, string outPath)
    {
        using var i = Image.FromFile(inPath);
        using var b = new Bitmap(i.Width, i.Height);
        using var g = Graphics.FromImage(b);

        g.DrawImage(i, new Rectangle(0, 0, i.Width, i.Height));
        
        g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(0, 0, 100, 100));
        
        /*for (var x = 0; x < b.Width; x++)
        {
            for (var y = 0; y < b.Width; y++)
            {
                b.SetPixel(x, y, Color.FromArgb(255, x, y, 0));
            }
        }*/
        
        b.Save(outPath, ImageFormat.Png);
    }

    public static void ShadeImage(string inPath, string outPath, Fragment fragShader)
    {
        using var i = Image.FromFile(inPath);
        using var b = new Bitmap(i.Width, i.Height);
        fragShader.SetResources(b);
        using var g = Graphics.FromImage(b);
        
        g.DrawImage(i, new Rectangle(0, 0, i.Width, i.Height));
        
        Console.WriteLine($"[SHADING]  Line progress ({b.Width}): [");
        for (var x = 0; x < b.Width; x++)
        {
            for (var y = 0; y < b.Height; y++)
            {
                b.SetPixel(x, y, fragShader.SetFragment(x, y));
            }
            Console.Write("/");
        }
        Console.WriteLine("\n]");
        
        b.Save(outPath, ImageFormat.Png);
    }
}