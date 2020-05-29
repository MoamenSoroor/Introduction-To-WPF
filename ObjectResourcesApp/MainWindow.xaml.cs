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

namespace ObjectResourcesApp
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

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            // access resource and make a change in it
            RadialGradientBrush brush = this.Resources["myBrush"] as RadialGradientBrush;
            if(brush != null) 
                brush.GradientStops[1] = new GradientStop(Colors.Black, 0.0);
        }

        // StaticResource
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Will NOT affects with Resource object Change as it is used as StaticResource
            // Put a totally new brush into the myBrush slot.
            this.Resources["myBrush"] = new SolidColorBrush(Colors.Red);
        }

        // DynamicResource
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            // Will affects with Resource object Change as it is used as DynamicResource
            // Put a totally new brush into the myBrush slot.
            this.Resources["myBrush"] = new SolidColorBrush(Colors.Green);
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
