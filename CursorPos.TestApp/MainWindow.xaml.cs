using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CursorPos.Models;
using Orientation = System.Windows.Controls.Orientation;

namespace CursorPos.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowInteropHelper _interopHelper;
        
        public MainWindow()
        {
            InitializeComponent();
            UpdateCursorPosition();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            _interopHelper = new WindowInteropHelper(this);
            var handle = _interopHelper.Handle;

            var windowSize = ScreenPosition.GetWindowClientSize(handle);
            
            var windowStartPoint = ScreenPosition.GetAbsolutePoint(new Point2D(0, 0), handle);
            var windowEndPoint = ScreenPosition.GetAbsolutePoint(new Point2D(windowSize.Width, windowSize.Height), handle);
            var pointToMoveCursor = VectorMath.GetIntermediatePointXY(windowStartPoint, windowEndPoint, 1D / 3);
            MouseCursor.SetPosition(windowStartPoint);
            await MouseCursor.MoveCursorAsync(new Point2D(1919, windowStartPoint.Y), TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(30));
        }

        private async void UpdateCursorPosition()
        {
            while (true)
            {
                var position = MouseCursor.GetPosition();
                CursorPositionTextBlock.Text = $"{position.X}; {position.Y}";
                await Task.Delay(50);
            }
        }
        
        private static double PointsToPixels(double wpfPoints, Orientation direction)
        {
            return direction == Orientation.Horizontal
                ? wpfPoints * Screen.PrimaryScreen.WorkingArea.Width / SystemParameters.WorkArea.Width
                : wpfPoints * Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.WorkArea.Height;
        }
        
        private static Size GetElementPixelSize(UIElement element)
        {
            Matrix transformToDevice;
            var source = PresentationSource.FromVisual(element);
            if (source!=null)
            {
                if (source.CompositionTarget != null)
                {
                    transformToDevice = source.CompositionTarget.TransformToDevice;
                }
            }
            else
            {
                using var hwndSource = new HwndSource(new HwndSourceParameters());
                var compositionTarget = ((PresentationSource) hwndSource).CompositionTarget;
                if (compositionTarget != null)
                {
                    transformToDevice = compositionTarget.TransformToDevice;
                }
            }

            if(element.DesiredSize == new Size())
                element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            return (Size)transformToDevice.Transform((Vector)element.DesiredSize);
        }
    }
}