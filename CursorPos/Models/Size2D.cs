using System.Runtime.InteropServices;

namespace CursorPos.Models
{
    /// <summary>
    /// Represents the size of the area in two-dimensional space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Size2D
    {
        /// <summary>
        /// Specifies the rectangle's width.
        /// </summary>
        public readonly int Width;
        /// <summary>
        /// Specifies the rectangle's height.
        /// </summary>
        public readonly int Height;

        public Size2D(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString() => $"{Width}x{Height}";
    }
}