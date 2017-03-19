using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Microsoft.Win32;
using TextConverter.ConverterBuilders;

namespace TextConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConverterBuilder builder;
        private Parser.Parser parser;

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDialogs();
        }

        private void InitializeDialogs()
        {
            openFileDialog = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt"
            };

            saveFileDialog = new SaveFileDialog();
        }

        private void openMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    mainTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        $"Text converter can't open a file!\n{ex.Message}",
                        "Unexpected error!", MessageBoxButton.OK);
                }
            }
        }

        private void saveMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void parserButton_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string tag = button?.Tag.ToString();

            // TODO: should we check button with other method?
            if (tag == htmlParserButton?.Tag.ToString())
            {

            }
            else if (tag == markdownParserButton?.Tag.ToString())
            {

            }
        }

        private void mainTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: syntax highlighting
            // ...

            // Uncomment this when builder's methods are implemented
            //resultTextBox.Text = parser.Parse(builder, (sender as TextBox)?.Text);
        }
    }
}
