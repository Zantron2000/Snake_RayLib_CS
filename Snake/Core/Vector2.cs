using System.Diagnostics.CodeAnalysis;

namespace Snake.Core
{
    public struct Vector2(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;

        public override readonly bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Vector2 other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }
    }
}