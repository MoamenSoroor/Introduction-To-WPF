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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.btnCanvas.Click += BtnCanvas_Click;
            this.btnGrid.Click += BtnGrid_Click;
            this.btnGridSplitter.Click += BtnGridSplitter_Click;
            this.btnStackPanel.Click += BtnStackPanel_Click;
            this.btnDockPanel.Click += BtnDockPanel_Click;
            this.btnScrollVierwer.Click += BtnScrollVierwer_Click;

            this.AddNewWindow<TestDesignerWindow>("Test Designer Window");
            this.AddNewWindow<WordPadWindow>("My Spell Checker Window");


        }

        private void LaunchWindow(Window window)
        {
            window.Owner = this;
            window.ShowDialog();
            
        }

        

        private void BtnScrollVierwer_Click(object sender, RoutedEventArgs e)
        {
            LaunchWindow(new ScrollViewerWindow());
        }

        private void BtnDockPanel_Click(object sender, RoutedEventArgs e)
        {
            LaunchWindow(new DockPanelWindow());
        }

        private void BtnStackPanel_Click(object sender, RoutedEventArgs e)
        {
            LaunchWindow(new StackPanelWindow());

        }

        private void BtnGridSplitter_Click(object sender, RoutedEventArgs e)
        {
            LaunchWindow(new GridSplitterWindow());
        }

        private void BtnGrid_Click(object sender, RoutedEventArgs e)
        {
            LaunchWindow(new GridWindow());
        }

        private void BtnCanvas_Click(object sender, RoutedEventArgs e)
        {
            LaunchWindow(new CanvasWindow());
        }

        private void AddNewWindow<T>(string text) where T:Window, new()
        {
            Button btn = new Button();
            btn.Content = text;
            btn.FontSize = 30;

            this.stackPanel.Children.Add(btn);

            btn.Click += (o, e) =>
            {
                T window = new T();
                window.Title = text;
                LaunchWindow(window);
            };
        }

    }
}
