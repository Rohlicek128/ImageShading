namespace ImageShading.Math;

public struct Vec4
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z  { get; set; }
    public float W  { get; set; }

    public float R
    {
        get => X;
        set => X = value;
    }
    public float G
    {
        get => Y;
        set => Y = value;
    }
    public float B
    {
        get => Z;
        set => Z = value;
    }
    public float A
    {
        get => W;
        set => W = value;
    }

    public Vec4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
    public Vec4(float scalar)
    {
        X = scalar;
        Y = scalar;
        Z = scalar;
        W = scalar;
    }
    public Vec4(Vec3 vec3, float w)
    {
        X = vec3.X;
        Y = vec3.Y;
        Z = vec3.Z;
        W = w;
    }

    public static Vec4 operator+(Vec4 left, Vec4 right)
    {
        return new Vec4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
    }
    public void operator+=(Vec4 other)
    {
        X += other.X;
        Y += other.Y;
        Z += other.Z;
        W += other.W;
    }
    
    public static Vec4 operator-(Vec4 left, Vec4 right)
    {
        return new Vec4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
    }
    public void operator-=(Vec4 other)
    {
        X -= other.X;
        Y -= other.Y;
        Z -= other.Z;
        W -= other.W;
    }
    
    public static Vec4 operator*(Vec4 left, Vec4 right)
    {
        return new Vec4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
    }
    public void operator*=(Vec4 other)
    {
        X *= other.X;
        Y *= other.Y;
        Z *= other.Z;
        W *= other.W;
    }
    public void operator*=(float scaler)
    {
        X *= scaler;
        Y *= scaler;
        Z *= scaler;
        W *= scaler;
    }
    
    public static Vec4 operator/(Vec4 left, Vec4 right)
    {
        return new Vec4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
    }
    public void operator/=(Vec4 other)
    {
        X /= other.X;
        Y /= other.Y;
        Z /= other.Z;
        W /= other.W;
    }
    public void operator/=(float scaler)
    {
        X /= scaler;
        Y /= scaler;
        Z /= scaler;
        W /= scaler;
    }
    
    public float this[int i]=> i switch
    {
        0 => X,
        1 => Y,
        2 => Z,
        3 => W,
        _ => throw new IndexOutOfRangeException()
    };


    public float Lenght()
    {
        return MathF.Sqrt(X*X + Y*Y + Z*Z + W*W);
    }

    public Vec4 Normalize()
    {
        var lenght = Lenght();
        this /= lenght;
        return this;
    }
    public Vec4 Normalized()
    {
        var lenght = Lenght();
        return new Vec4(X / lenght, Y / lenght, Z / lenght, W / lenght);
    }
    

    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }
}