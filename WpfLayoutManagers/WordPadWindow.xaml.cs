using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
    /// Interaction logic for WordPadWindow.xaml
    /// </summary>
    public partial class WordPadWindow : Window
    {
        public WordPadWindow()
        {
            InitializeComponent();

            this.menuFileExit.Click += Exit_Click;
            this.menuFileExit.MouseEnter += Exit_MouseEnter;
            this.menuFileExit.MouseLeave += General_MouseLeave;

            this.menuCheck.Click += Check_Click;
            this.menuCheck.MouseEnter += Check_MouseEnter;
            this.menuCheck.MouseLeave += General_MouseLeave;

            this.btnExit.Click += Exit_Click;
            this.btnCheck.Click += Check_Click;

            SetHelpCommandBinding();
            SetOpenCommandBinding();
            SetSaveCommandBinding();

        }

        private static readonly string NL = System.Environment.NewLine;

        private void SetSaveCommandBinding()
        {
            CommandBinding binding = new CommandBinding(ApplicationCommands.Save);
            binding.CanExecute += SaveCommandBinding_CanExecute;
            binding.Executed += SaveCommandBinding_Executed;
            this.CommandBindings.Add(binding);
        }

        private void SetOpenCommandBinding()
        {
            CommandBinding binding = new CommandBinding(ApplicationCommands.Open);
            binding.CanExecute += OpenCommandBinding_CanExecute;
            binding.Executed += OpenCommandBinding_Executed;
            this.CommandBindings.Add(binding);
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files(*.*) |*.*";

            if (dialog.ShowDialog() == true)
            {
                txtData.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void OpenCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Text Files (*.txt)|*.txt|All Files(*.*) |*.*";
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, txtData.Text);
            }
        }

        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }



        private void SetHelpCommandBinding()
        {
            CommandBinding binding = new CommandBinding(ApplicationCommands.Help);
            binding.CanExecute += HelpCommandBinding_CanExecute;
            binding.Executed += HelpCommandBinding_Executed;
            //this.menu.CommandBindings.Add(binding);
            this.CommandBindings.Add(binding);
        }

        private void HelpCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("It is easy man go back and just press Check.","Help");
        }

        private void HelpCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void General_MouseLeave(object sender, MouseEventArgs e)
        {
            this.statusBarText.Text = "Ready";
        }

        private void Check_MouseEnter(object sender, MouseEventArgs e)
        {
            this.statusBarText.Text = "Show Spelling Suggestions";
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            ViewSpellChecking();
        }

        private void ViewSpellChecking()
        {
            string spellingHints = string.Empty;
            // Try to get a spelling error at the current caret location.
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if (error != null)
            {
                // Build a string of spelling suggestions.
                foreach (string s in error.Suggestions)
                {
                    spellingHints += $"{s}{NL}";
                }

                // Show suggestions and expand the expander.
                lblSpellingHints.Content = spellingHints;
                expander.IsExpanded = true;
            }
            else
            {
                lblSpellingHints.Content = "No Available Hints!";
                expander.IsExpanded = true;
            }
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            this.statusBarText.Text = "Exit the App";
        }


    }
}
