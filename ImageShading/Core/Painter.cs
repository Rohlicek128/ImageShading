using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using ImageShading.Math;

namespace ImageShading.Core;

public static class Painter
{
    public static void ShadeImage(string inPath, string outPath, Fragment fragShader, bool open = false)
    {
        var sw = new Stopwatch();
        sw.Start();
        
        using var i = Image.FromFile(inPath);
        using var b = new Bitmap(i.Width, i.Height, PixelFormat.Format32bppArgb);
        var width = i.Width;
        var height = i.Height;
        
        using var g = Graphics.FromImage(b);
        g.DrawImage(i, new Rectangle(0, 0, width, height));

        
        var data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, b.PixelFormat);
        var bytesPerPixel = Image.GetPixelFormatSize(b.PixelFormat) / 8;
        var stride = data.Stride;
        
        var inputBuffer = new byte[stride * height];
        Marshal.Copy(data.Scan0, inputBuffer, 0, inputBuffer.Length);
        Buffer buffer;
        buffer.Data = inputBuffer;
        buffer.Width = width;
        buffer.Height = height;
        buffer.Stride = stride;
        fragShader.SetBuffer(buffer);
        
        
        Console.Write($"[SHADING] Rendering ({width}px | {height}px): ");
        unsafe
        {
            var pixelPtr = (byte*)data.Scan0;
            
            Parallel.For(0, height, y =>
            {
                var row = pixelPtr + y * stride;

                for (var x = 0; x < width; x++)
                {
                    var color = fragShader.SetFragment(new Vec2(x / (float)width, y / (float)height));
                    row[x * bytesPerPixel + 0] = (byte)(MathF.Min(MathF.Max(color.B, 0f), 1f) * 255f);
                    row[x * bytesPerPixel + 1] = (byte)(MathF.Min(MathF.Max(color.G, 0f), 1f) * 255f);
                    row[x * bytesPerPixel + 2] = (byte)(MathF.Min(MathF.Max(color.R, 0f), 1f) * 255f);
                    row[x * bytesPerPixel + 3] = (byte)(MathF.Min(MathF.Max(color.A, 0f), 1f) * 255f);
                }
                //Console.Write("/");
            });
        }
        //Console.WriteLine("\n]");
        Console.Write("FINISHED");
        
        b.UnlockBits(data);
        b.Save(outPath, ImageFormat.Png);
        
        sw.Stop();
        Console.WriteLine($", {sw.Elapsed}");
        
        if (open) OpenImage(outPath);
    }

    public static void OpenImage(string path)
    {
        Console.WriteLine($"[SHADING] Opening \"{path}\"");
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(startInfo);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[ERROR] Failed to open \"{path}\": {e.Message}");
        }
    }
}