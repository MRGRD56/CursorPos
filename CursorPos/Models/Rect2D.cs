using System.Runtime.InteropServices;

namespace CursorPos.Models
{
    /// <summary>
    /// Represents a rectangle in two-dimensional space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Rect2D
    {
        /// <summary>
        /// Specifies the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public readonly int Left;
        /// <summary>
        /// Specifies the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public readonly int Top;
        /// <summary>
        /// Specifies the x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public readonly int Right;
        /// <summary>
        /// Specifies the y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public readonly int Bottom;

        public Rect2D(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public Size2D GetSize() => new(Right - Left, Bottom - Top);
    }
}