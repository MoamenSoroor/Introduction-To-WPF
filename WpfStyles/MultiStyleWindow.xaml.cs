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

namespace WpfStyles
{
    /// <summary>
    /// Interaction logic for MultiStyleWindow.xaml
    /// </summary>
    public partial class MultiStyleWindow : Window
    {
        public MultiStyleWindow()
        {
            InitializeComponent();
            // Fill the list box with all the Button styles. but i make it in xaml code
            lstStyles.Items.Add("AnimatedButton");
            lstStyles.Items.Add("TiltButton");
            lstStyles.Items.Add("BigGreenButton");
            lstStyles.Items.Add("BasicControlStyle");
        }

        private void lstStyles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myStyle = this.TryFindResource(this.lstStyles.SelectedValue) as Style;
            if (myStyle != null)
                this.btnStyle.Style = myStyle;
        }
    }
}
