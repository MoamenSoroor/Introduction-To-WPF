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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimationInXaml
{
    /// <summary>
    /// Interaction logic for AnimateStringWindow.xaml
    /// </summary>
    public partial class AnimateStringWindow : Window
    {
        public AnimateStringWindow()
        {
            InitializeComponent();

            myButton2.Loaded += MyButton_Loaded;
            //myButton2.Click += MyButton_Loaded;
        }

        private void MyButton_Loaded(object sender, RoutedEventArgs e)
        {
            StringAnimationUsingKeyFrames anime = new StringAnimationUsingKeyFrames()
            {
                AutoReverse = true,
                Duration = new Duration(TimeSpan.FromSeconds(2.5)),
                RepeatBehavior = RepeatBehavior.Forever
            };

            anime.KeyFrames.Add(new DiscreteStringKeyFrame("",KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
            anime.KeyFrames.Add(new DiscreteStringKeyFrame("O",KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.5))));
            anime.KeyFrames.Add(new DiscreteStringKeyFrame("OK",KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1))));
            anime.KeyFrames.Add(new DiscreteStringKeyFrame("OK!",KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.5))));
            anime.KeyFrames.Add(new DiscreteStringKeyFrame("OK!!",KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2))));

            myButton2.BeginAnimation(Button.ContentProperty, anime);
        }
    }
}
