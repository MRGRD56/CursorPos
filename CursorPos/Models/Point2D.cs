using System.Runtime.InteropServices;

namespace CursorPos.Models
{
    /// <summary>
    /// Represents a point in two-dimensional space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Point2D
    {
        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public readonly int X;
        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        public readonly int Y;

        public Point2D(int x, int y)
        {
            (X, Y) = (x, y);
        }

        public Point2D(double x, double y)
        {
            (X, Y) = (VectorMath.RoundNumber(x), VectorMath.RoundNumber(y));
        }

        public Point2D WithX(int x) => new(x, Y);
        public Point2D WithY(int y) => new(X, y);

        public static Point2D operator +(Point2D a, Point2D b) => new(a.X + b.X, a.Y + b.Y);
        public static Point2D operator -(Point2D a, Point2D b) => new(a.X - b.X, a.Y - b.Y);
        public static Point2D operator *(Point2D a, Point2D b) => new(a.X * b.X, a.Y * b.Y);
        public static Point2D operator /(Point2D a, Point2D b) => new((double) a.X /  b.X, (double) a.Y / b.Y);
        
        public static Point2D operator +(Point2D a) => a;
        public static Point2D operator -(Point2D a) => new(-a.X, -a.Y);

        public static bool operator ==(Point2D a, Point2D b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Point2D a, Point2D b) => !(a == b);

        public override string ToString() => $"{X};{Y}";
    }
}