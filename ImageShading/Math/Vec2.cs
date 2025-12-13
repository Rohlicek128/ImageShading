namespace ImageShading.Math;

public struct Vec2
{
    public float X { get; set; }
    public float Y { get; set; }

    public Vec2(float x, float y)
    {
        X = x;
        Y = y;
    }
    public Vec2(float scalar)
    {
        X = scalar;
        Y = scalar;
    }

    public static Vec2 operator+(Vec2 left, Vec2 right)
    {
        return new Vec2(left.X + right.X, left.Y + right.Y);
    }
    public void operator+=(Vec2 other)
    {
        X += other.X;
        Y += other.Y;
    }
    
    public static Vec2 operator-(Vec2 left, Vec2 right)
    {
        return new Vec2(left.X - right.X, left.Y - right.Y);
    }
    public void operator-=(Vec2 other)
    {
        X -= other.X;
        Y -= other.Y;
    }
    
    public static Vec2 operator*(Vec2 left, Vec2 right)
    {
        return new Vec2(left.X * right.X, left.Y * right.Y);
    }
    public void operator*=(Vec2 other)
    {
        X *= other.X;
        Y *= other.Y;
    }
    public void operator*=(float scaler)
    {
        X *= scaler;
        Y *= scaler;
    }
    
    public static Vec2 operator/(Vec2 left, Vec2 right)
    {
        return new Vec2(left.X / right.X, left.Y / right.Y);
    }
    public void operator/=(Vec2 other)
    {
        X /= other.X;
        Y /= other.Y;
    }
    public void operator/=(float scaler)
    {
        X /= scaler;
        Y /= scaler;
    }
    
    public float this[int i]=> i switch
    {
        0 => X,
        1 => Y,
        _ => throw new IndexOutOfRangeException()
    };


    public float Lenght()
    {
        return MathF.Sqrt(X*X + Y*Y);
    }

    public Vec2 Normalize()
    {
        var lenght = Lenght();
        this /= lenght;
        return this;
    }
    public Vec2 Normalized()
    {
        var lenght = Lenght();
        return new Vec2(X / lenght, Y / lenght);
    }
    

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}