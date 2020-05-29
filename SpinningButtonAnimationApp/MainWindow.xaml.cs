using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SpinningButtonAnimationApp
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

        bool isSpin = false;
        private void btnSpinning_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isSpin)
            {
                isSpin = true;
                var anime = new DoubleAnimation()
                {
                    From = 0,
                    To = 360,
                    By = 1
                };

                anime.Completed += (a, b) => isSpin = false;

                anime.Duration = new Duration(TimeSpan.FromSeconds(4));
                anime.RepeatBehavior = RepeatBehavior.Forever;    // Forever
                //anime.RepeatBehavior = new RepeatBehavior(3);  // 3 times
                //anime.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(3)); // 3 seconds

                RotateTransform rotate = new RotateTransform();

                btnSpinning.RenderTransformOrigin = new Point(0.5, 0.5);
                btnSpinning.RenderTransform = rotate;



                rotate.BeginAnimation(RotateTransform.AngleProperty, anime);
            }



        }


        bool isClicked = false;
        private void btnSpinning_Click(object sender, RoutedEventArgs e)
        {
            if (!isClicked)
            {
                isClicked = true;
                var anime = new DoubleAnimation
                {
                    From = 1.0,
                    To = 0.0,
                    AutoReverse = true
                };
                anime.Completed += (a, b) => isClicked = false;
                anime.RepeatBehavior = RepeatBehavior.Forever;

                btnSpinning.BeginAnimation(Button.OpacityProperty, anime);

            }
            
        }
    }
}
