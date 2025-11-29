using System.Drawing;

namespace ImageShading.Core;

public abstract class Fragment
{
    private Bitmap? _screenBuffer;

    public void SetResources(Bitmap screen)
    {
        _screenBuffer = screen;
    }

    protected Color SampleScreenBuffer(int x, int y)
    {
        if (_screenBuffer == null) return Color.Black;
        //if (x % _screenBuffer.Width == 0) Console.WriteLine("g");
        
        return _screenBuffer.GetPixel(x % _screenBuffer.Width, y % _screenBuffer.Height);
    }
    
    public abstract Color SetFragment(int x, int y);
}