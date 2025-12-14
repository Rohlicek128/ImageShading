namespace ImageShading.Math;

public struct Vec3
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z  { get; set; }
    
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

    public Vec3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public Vec3(float scalar)
    {
        X = scalar;
        Y = scalar;
        Z = scalar;
    }

    public static Vec3 operator+(Vec3 left, Vec3 right)
    {
        return new Vec3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }
    public void operator+=(Vec3 other)
    {
        X += other.X;
        Y += other.Y;
        Z += other.Z;
    }
    
    public static Vec3 operator-(Vec3 left, Vec3 right)
    {
        return new Vec3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }
    public void operator-=(Vec3 other)
    {
        X -= other.X;
        Y -= other.Y;
        Z -= other.Z;
    }
    
    public static Vec3 operator*(Vec3 left, Vec3 right)
    {
        return new Vec3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
    }
    public static Vec3 operator*(Vec3 left, float scalar)
    {
        return new Vec3(left.X * scalar, left.Y * scalar, left.Z * scalar);
    }
    public void operator*=(Vec3 other)
    {
        X *= other.X;
        Y *= other.Y;
        Z *= other.Z;
    }
    public void operator*=(float scaler)
    {
        X *= scaler;
        Y *= scaler;
        Z *= scaler;
    }
    
    public static Vec3 operator/(Vec3 left, Vec3 right)
    {
        return new Vec3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
    }
    public static Vec3 operator/(Vec3 left, float scalar)
    {
        return new Vec3(left.X / scalar, left.Y / scalar, left.Z / scalar);
    }
    public void operator/=(Vec3 other)
    {
        X /= other.X;
        Y /= other.Y;
        Z /= other.Z;
    }
    public void operator/=(float scaler)
    {
        X /= scaler;
        Y /= scaler;
        Z /= scaler;
    }
    
    public float this[int i]=> i switch
    {
        0 => X,
        1 => Y,
        2 => Z,
        _ => throw new IndexOutOfRangeException()
    };


    public float Lenght()
    {
        return MathF.Sqrt(X*X + Y*Y + Z*Z);
    }

    public Vec3 Normalize()
    {
        var lenght = Lenght();
        this /= lenght;
        return this;
    }
    public Vec3 Normalized()
    {
        var lenght = Lenght();
        return new Vec3(X / lenght, Y / lenght, Z / lenght);
    }

    public static float Dot(Vec3 left, Vec3 right)
    {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
    }
    

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}