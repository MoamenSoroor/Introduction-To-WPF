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
using System.Windows.Shapes;

namespace WpfLayoutManagers
{
    /// <summary>
    /// Interaction logic for TestDesignerWindow.xaml
    /// </summary>
    public partial class TestDesignerWindow : Window
    {
        public TestDesignerWindow()
        {
            InitializeComponent();
        }

        private static readonly string NL = System.Environment.NewLine;

        string mouseActivity = string.Empty;
        private void AddEventInfo(object sender, RoutedEventArgs e)
        {
            mouseActivity += $"{sender} sends a {e.RoutedEvent.RoutingStrategy} Event, Named:{e.RoutedEvent.Name}{NL}";
        }

        private async void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("Eclipse Mouse Down ", "Ellipse");
            this.Title = "You Press The Green Ellipse";

            // Continuing or Halting Bubbling
            e.Handled = false;  // Continuing Bubbling 
            //e.Handled = true;   // Stop Bubbling / Halting Bubbling , and this is the default

            //Task.Delay(1000).GetAwaiter().OnCompleted(() => this.Title = "Test Designer Window");
            await Task.Delay(1000);
            this.Title = "Test Designer Window";
        }

        private void BigButton_Click(object sender, RoutedEventArgs e)
        {
            AddEventInfo(sender, e);
            MessageBox.Show(mouseActivity, "Your Event Info:");
            mouseActivity = "";
        }

        
        private void OuterEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddEventInfo(sender, e);
        }


        private void OuterEllipse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddEventInfo(sender, e);
            //e.Handled = false;
        }

        
    }
}
