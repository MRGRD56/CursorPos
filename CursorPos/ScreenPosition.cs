using System;
using CursorPos.Exceptions;
using CursorPos.Models;
using CursorPos.WinApi;

namespace CursorPos
{
    public static class ScreenPosition
    {
        /// <summary>
        /// Converts the client-area coordinates of a specified point to screen coordinates..
        /// </summary>
        /// <param name="windowRelativePoint">A point on the screen relative to the window.</param>
        /// <param name="windowHandle">A handle of the window</param>
        /// <returns>An absolute point on the screen.</returns>
        public static Point2D GetAbsolutePoint(Point2D windowRelativePoint, IntPtr windowHandle)
        {
            WinApiInterop.CheckIfSuccess(
                User32.ClientToScreen(windowHandle, ref windowRelativePoint), 
                "Unable to get an absolute point");
            return windowRelativePoint;
        }

        public static Size2D GetWindowSize(IntPtr windowHandle)
        {
            WinApiInterop.CheckIfSuccess(
                User32.GetWindowRect(windowHandle, out var rect),
                "Unable to get the window rectangle");
            return rect.GetSize();
        }
        
        public static Size2D GetWindowClientSize(IntPtr windowHandle)
        {
            WinApiInterop.CheckIfSuccess(
                User32.GetClientRect(windowHandle, out var rect),
                "Unable to get the window client area rectangle");
            return rect.GetSize();
        }
    }
}