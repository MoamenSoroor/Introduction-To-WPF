using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTesterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Closing += MainWindow_Closing;
            this.Closed += MainWindow_Closed;
            this.MouseMove += MainWindow_MouseMove;
            this.KeyUp += MainWindow_KeyUp;
            this.Activated += MainWindow_Activated;
            this.Deactivated += MainWindow_Deactivated;

            this.StateChanged += MainWindow_StateChanged;


        }

        private static string NL = System.Environment.NewLine;



        // ========================> Keyboard Events <========================
        #region Keyboard Events
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            this.textBox.Text = e.Key.ToString();
        }
        // ===========================================================================
        #endregion

        // ========================> Mouse Events <========================
        #region Mouse Events
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            //this.textBox1.Text = $"Pos:{e.GetPosition(this)}";
            this.Title = e.GetPosition(this).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string msg = (bool)Application.Current.Properties["KingMode"] ?
                "King Mode Activated !!!\t\t"
                : "Hello Good App!!\t\t";

            MessageBox.Show(msg, "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);


        }
        // ===========================================================================
        #endregion

        // ========================> Window Events <========================
        #region Window CLosing Events
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            //MessageBox.Show("Goodbye !!\t\t");
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg = "Do you really want to close without saving?";
            MessageBoxResult result = MessageBox.Show(
                msg,
                "Close",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                e.Cancel = true;

        }

        private void MainWindow_Deactivated(object sender, EventArgs e)
        {
            textBox2.AppendText("Window Deactivated at" + DateTime.Now.ToShortTimeString() + NL);
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            textBox2.AppendText("Window Activated at" + DateTime.Now.ToShortTimeString() + NL);
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            textBox3.AppendText("Window State:" + this.WindowState + NL);
        }


        // ===========================================================================
        #endregion

    }
}

