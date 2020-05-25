using AutoLotDAL.Repos;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlsAndAPIs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadColors();

            this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            SelectColorByName("black");


            SetBindings();
            ConfigureGrid();
        }

        private void SetBindings()
        {
            Binding binding = new Binding();

            binding.Converter = new MyDoubleConverter();
            binding.Source = this.mySB;
            binding.Path = new PropertyPath("Value");

            this.label5.SetBinding(Label.ContentProperty, binding);
        }

        public static readonly Dictionary<string, string> Colors = ColorComboBoxItem.Colors;

        private void LoadColors()
        {
            comboColors.ItemsSource = Colors.Select(c => new ColorComboBoxItem(c.Key)).ToList();

        }

        private void ConfigureGrid()
        {
            // Build a LINQ query that gets back some data from the Inventory table.
            using (var repo = new InventoryRepo())
            {
                gridInventory.ItemsSource = 
                    repo.GetAll().Select(x => new { x.Id, x.Make, x.Color, x.PetName });
            }
        }

        void SelectColorByName(string colorName)
        {
            comboColors.SelectedItem = this.comboColors.ItemsSource.OfType<ColorComboBoxItem>()
                .Where(item => item.ColorName.Equals(colorName, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault() ?? comboColors.SelectedItem;
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton)?.Content.ToString())
            {
                case "Ink Mode":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Select Mode":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "Erase Mode":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                default:
                    MessageBox.Show("Error,InkCanvasEditingMode Error.","Error");
                    break;
            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            this.MyInkCanvas.DefaultDrawingAttributes.Color =
                (this.comboColors.SelectedItem as ColorComboBoxItem)?.ColorValue 
                ?? this.MyInkCanvas.DefaultDrawingAttributes.Color;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Save ink canvas drawings
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Ink Files (*.ink)|*.ink";

            if (dialog.ShowDialog() == true)
            {
                using (FileStream fs = File.Open(dialog.FileName ,FileMode.Create))
                {
                    this.MyInkCanvas.Strokes.Save(fs);

                }
            }


        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files | *.* | Ink Files | *.ink";

            if (dialog.ShowDialog() == true)
            {
                using (FileStream fs = File.OpenRead(dialog.FileName))
                {
                    this.MyInkCanvas.Strokes = new StrokeCollection(fs);
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you really want to clear Canvas?", "Clear Canvas Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
                this.MyInkCanvas.Strokes.Clear();
        }
    }
}

