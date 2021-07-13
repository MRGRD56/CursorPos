using System;
using CursorPos.Models;

namespace CursorPos
{
    public static class VectorMath
    {
        public static double GetIntermediatePoint(int point1, int point2, double percentage) =>
            GetIntermediatePoint((double) point1, (double) point2, percentage);
        
        public static double GetIntermediatePoint(double point1, double point2, double percentage)
        {
            ValidatePercentage(percentage);
            return (point2 - point1) * percentage + point1;
        }

        public static Point2D GetIntermediatePointXY(Point2D point1, Point2D point2, double percentage)
        {
            ValidatePercentage(percentage);
            return new Point2D(
                GetIntermediatePoint(point1.X, point2.X, percentage), 
                GetIntermediatePoint(point1.Y, point2.Y, percentage));
        }
        
        internal static int RoundNumber(double number) => Convert.ToInt32(Math.Round(number));

        private static void ValidatePercentage(double percentage)
        {
            if (percentage is < 0 or > 1)
            {
                throw new ArgumentException("Percentage must be [0; 1]", nameof(percentage));
            }
        }
    }
}