using System;
using System.Runtime.InteropServices;
using CursorPos.Models;

namespace CursorPos.WinApi
{
    internal static class User32
    {
        private const string User32Dll = "user32.dll";

        [DllImport(User32Dll)]
        internal static extern bool GetCursorPos(out Point2D lpPoint);
        
        [DllImport(User32Dll)]
        internal static extern bool SetCursorPos(int x, int y);

        [DllImport(User32Dll)]
        internal static extern bool ClientToScreen(IntPtr hWnd, ref Point2D point);

        [DllImport(User32Dll)]
        internal static extern bool GetClientRect(IntPtr hWnd, out Rect2D lpRect);

        [DllImport(User32Dll)]
        internal static extern bool GetWindowRect(IntPtr hWnd, out Rect2D lpRect);
    }
}