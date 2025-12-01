using System.Drawing;

namespace ImageShading.Core;

public abstract class Fragment
{
    private Buffer? _screenBuffer;

    public void SetBuffer(Buffer buffer)
    {
        _screenBuffer = buffer;
    }

    protected Color SampleScreenBuffer(float x, float y)
    {
        if (!_screenBuffer.HasValue) return Color.Black;

        var index = ((y * _screenBuffer.Value.Height) % _screenBuffer.Value.Height) * _screenBuffer.Value.Stride +
                    ((x * _screenBuffer.Value.Width) % _screenBuffer.Value.Width) * 4;
        var iIndex = (int)index;
        
        return Color.FromArgb(
            _screenBuffer.Value.Data[iIndex + 3],
            _screenBuffer.Value.Data[iIndex + 2],
            _screenBuffer.Value.Data[iIndex + 1],
            _screenBuffer.Value.Data[iIndex + 0]
        );
    }
    
    public abstract Color SetFragment(float x, float y);
}