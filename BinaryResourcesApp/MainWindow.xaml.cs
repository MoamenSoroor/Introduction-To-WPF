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

namespace BinaryResourcesApp
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

        private ImageNavigator navigator;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                // \Images\image1.jpg
                //navigator = new ImageNavigator();
                //navigator.AddImage(new BitmapImage(new Uri($@"{path}\Images\image1.jpg")));
                //navigator.AddImage(new BitmapImage(new Uri($@"{path}\Images\image2.jpg")));
                //navigator.AddImage(new BitmapImage(new Uri($@"{path}\Images\image3.png")));

                // if images are embedded resources - embedded inside the assembly -
                // in it's properties marked as Resources, and don't copy
                navigator = new ImageNavigator();
                navigator.AddImage(new BitmapImage(new Uri($@"/Images/image1.jpg", UriKind.Relative)));
                navigator.AddImage(new BitmapImage(new Uri($@"/Images/image2.jpg", UriKind.Relative)));
                navigator.AddImage(new BitmapImage(new Uri($@"/Images/image3.png", UriKind.Relative)));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            
        }

        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            this.imageHolder.Source = navigator.Previous();
        }

        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            this.imageHolder.Source = navigator.Next();
        }

        private class ImageNavigator
        {
            private int current = -1;
            private readonly List<BitmapImage> images;

            public ImageNavigator()
            {
                this.images = new List<BitmapImage>();
            }

            public ImageNavigator(List<BitmapImage> images)
            {
                this.images = images;
            }

            public void AddImage(BitmapImage image)
            {
                this.images.Add(image);
            }

            public BitmapImage Next()
            {
                current = ++current % images.Count;
                return images[current];
            }

            public BitmapImage Previous()
            {
                current = --current == -1 ? images.Count - 1 : current;
                return images[current];
            }
        }
    }
}
