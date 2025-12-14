using ImageShading.Math;

namespace ImageShading.Core;

public abstract class Fragment
{
    private Buffer? _screenBuffer;

    public void SetBuffer(Buffer buffer)
    {
        _screenBuffer = buffer;
    }

    protected Vec4 SampleScreenBuffer(float x, float y)
    {
        if (!_screenBuffer.HasValue) return new Vec4(0f);
        
        var dnX = (int)(x * _screenBuffer.Value.Width) % _screenBuffer.Value.Width;
        var dnY = (int)(y * _screenBuffer.Value.Height) % _screenBuffer.Value.Height;
        if (dnX < 0f) dnX = _screenBuffer.Value.Width + dnX;
        if (dnY < 0f) dnY = _screenBuffer.Value.Height + dnY;
        
        var index = dnY * _screenBuffer.Value.Stride + dnX * 4;
        
        return new Vec4(
            _screenBuffer.Value.Data[index + 2] / 255f,
            _screenBuffer.Value.Data[index + 1] / 255f,
            _screenBuffer.Value.Data[index + 0] / 255f,
            _screenBuffer.Value.Data[index + 3] / 255f
        );
    }
    protected Vec4 SampleScreenBuffer(Vec2 coordinates)
    {
        return SampleScreenBuffer(coordinates.X, coordinates.Y);
    }
    
    public abstract Vec4 SetFragment(Vec2 coordinates);
}