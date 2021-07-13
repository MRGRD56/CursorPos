using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using CursorPos.Exceptions;
using CursorPos.Models;
using CursorPos.WinApi;

namespace CursorPos
{
    public static class MouseCursor
    {
        /// <summary>
        /// Returns the position of the mouse cursor.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnsuccessException">Thrown if it was not possible to get the cursor position.</exception>
        public static Point2D GetPosition()
        {
            WinApiInterop.CheckIfSuccess(
                User32.GetCursorPos(out var position),
                "Unable to get the cursor position");
            return position;
        }

        public static void SetPosition(Point2D position)
        {
            WinApiInterop.CheckIfSuccess(
                User32.SetCursorPos(position.X, position.Y),
                "Unable to set the cursor position");
        }

        public static void SetPosition(Point2D position, IntPtr windowHandle)
        {
            SetPosition(ScreenPosition.GetAbsolutePoint(position, windowHandle));
        }

        public static async Task MoveCursorAsync(
            Point2D position, 
            TimeSpan movingTime, 
            TimeSpan movingDelay, 
            CancellationToken cancellationToken = default)
        {
            var currentPosition = GetPosition();
            var lastPosition = currentPosition;
            for (var time = TimeSpan.Zero; 
                !cancellationToken.IsCancellationRequested && (time < movingTime || lastPosition != position); 
                time += movingDelay)
            {
                var percentage = time / movingTime;
                if (percentage > 1) percentage = 1;
                
                var point = VectorMath.GetIntermediatePointXY(currentPosition, position, percentage);
                SetPosition(point);
                lastPosition = point;
                Debug.WriteLine(point);
                await Task.Delay(movingDelay, cancellationToken);
            }
        }
    }
}