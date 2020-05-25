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

namespace CustomDepProp
{
    /// <summary>
    /// Interaction logic for ShowNumberControl.xaml
    /// </summary>
    public partial class ShowNumberControl : UserControl
    {
        public ShowNumberControl()
        {
            InitializeComponent();
        }


        // A normal, everyday .NET property.
        // private int _currNumber = 0;
        // public int CurrentNumber
        // {
        //     get => _currNumber;
        //     set
        //     {
        //         _currNumber = value;
        //         numberDisplay.Content = CurrentNumber.ToString();
        //     }
        // }




        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register("CurrentNumber"
                , typeof(int)
                , typeof(ShowNumberControl)
                , new UIPropertyMetadata(100, new PropertyChangedCallback(CurrentNumberChanged))
                , new ValidateValueCallback(ValidateCurrentNumber));

        private static void CurrentNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ShowNumberControl control = d as ShowNumberControl;
            control.numberDisplay.Content = e.NewValue.ToString();
        }

        private static bool ValidateCurrentNumber(object value)
        {
            // simple business rule.
            return value is int n && n >= 0 && n <= 500;
        }
    }
}
