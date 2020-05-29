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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationInXaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AnimateStringWindow window = new AnimateStringWindow();
            window.Show();



            this.Loaded += MainWindow_Loaded;

            //DoubleAnimation anime = new DoubleAnimation()
            //{
            //    From = 12,
            //    To = 100,
            //    By = 1,
            //    Duration = new Duration(TimeSpan.FromSeconds(2)),
            //    RepeatBehavior = RepeatBehavior.Forever,
            //    AutoReverse = true
            //};

            //this.lblAnime.BeginAnimation(Label.FontSizeProperty, anime);


        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            

            //DoubleAnimation anime = new DoubleAnimation()
            //{
            //    From = 10,
            //    To = 100,
            //    By = 1,
            //    Duration = new Duration(TimeSpan.FromSeconds(4)),
            //    RepeatBehavior = RepeatBehavior.Forever,
            //    AutoReverse = true
            //};

            //Storyboard storyboard = new Storyboard();
            //storyboard.Children.Add(anime);
            //BeginStoryboard begin = new BeginStoryboard();
            //begin.Storyboard = storyboard;

            //EventTrigger trigger = new EventTrigger(Label.LoadedEvent);

            //trigger.Actions.Add(begin);
            //this.lblAnime.Triggers.Add(trigger);

        }
    }
}
