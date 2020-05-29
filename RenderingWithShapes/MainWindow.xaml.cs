using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RenderingWithShapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private enum SelectedShape
        { Circle, Rectangle, Line }

        private SelectedShape currentShape;

        private void rectOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Rectangle;
        }

        private void lineOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Line;
        }

        private void circleOption_Click(object sender, RoutedEventArgs e)
        {
            currentShape = SelectedShape.Circle;
        }

        private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Shape shape = null;
            switch (currentShape)
            {
                case SelectedShape.Circle:
                    shape = new Ellipse() 
                    { Fill = GreenGradient() , Height = 35, Width = 35};
                    break;
                case SelectedShape.Rectangle:
                    shape =  new Rectangle()
                    { Fill = Brushes.Red, Height = 35, Width = 35, RadiusX = 10, RadiusY = 10 };
                    break;
                case SelectedShape.Line:
                    shape = new Line()
                    {
                        Stroke = Brushes.Blue,
                        StrokeThickness = 10,
                        X1 = 0,
                        X2 = 50,
                        Y1 = 0,
                        Y2 = 50,
                        StrokeStartLineCap = PenLineCap.Triangle,
                        StrokeEndLineCap = PenLineCap.Round
                    };
                    break;
                default:
                    break;
            }

            // Set top/left position to draw in the canvas.
            Canvas.SetLeft(shape, e.GetPosition(canvasDrawingArea).X);
            Canvas.SetTop(shape, e.GetPosition(canvasDrawingArea).Y);
            // Draw shape!
            canvasDrawingArea.Children.Add(shape);
        }

        private void canvasDrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this.canvasDrawingArea);

            HitTestResult result = VisualTreeHelper.HitTest(this.canvasDrawingArea, point);
            
            if (result != null)
            {
                this.canvasDrawingArea.Children.Remove(result.VisualHit as Shape);
            }
        }

        private Brush GreenGradient()
        {
            var brush = new LinearGradientBrush();

            brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF77F177"), 0));
            brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF11E611"), 1));
            brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF5A8E5A "), 0.5));

            return brush;
        }

        private void flipCanvas_Click(object sender, RoutedEventArgs e)
        {
            if (flipCanvas.IsChecked == true)
            {
                RotateTransform rotate = new RotateTransform(-180);
                canvasDrawingArea.LayoutTransform = rotate;
            }
            else
            {
                canvasDrawingArea.LayoutTransform = null;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            canvasDrawingArea.Children.Clear();
        }
    }
}
