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

        // I don't like this.
        private List<Button> parserButtons;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDialogs();
            InitializeConverter();
        }

        #region Initializators

        private void InitializeDialogs()
        {
            openFileDialog = new OpenFileDialog
            {
                // TODO: get it from resourses
                Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt"
            };

            saveFileDialog = new SaveFileDialog();
        }

        private void InitializeConverter()
        {
            parser = new Parser.Parser();
            SetBuilder(ref builder, new HtmlBuilder());

            parserButtons = new List<Button>
            {
                htmlParserButton, markdownParserButton
            };

            HightlightButton(htmlParserButton, parserButtons);
        }

        #endregion

        #region MenuItems OnClick events

        private void openMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    saveFileDialog.FileName = null;
                    mainTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    // TODO: get it from resourses
                    MessageBox.Show(this,
                        $"Text converter can't open a file!\n{ex.Message}",
                        "Unexpected error!", MessageBoxButton.OK);
                }
            }
        }

        private void saveMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            string tag = menuItem?.Tag.ToString();
            string prevFilePath = saveFileDialog.FileName;

            try
            {
                if ((string.IsNullOrEmpty(prevFilePath) || tag == saveAsMenuItem?.Tag.ToString()) &&
                    saveFileDialog.ShowDialog() == true &&
                    string.Equals(saveFileDialog.FileName, prevFilePath, StringComparison.CurrentCultureIgnoreCase))
                {
                    string newFilePath = saveFileDialog.FileName;
                    var path = System.IO.Path.GetDirectoryName(newFilePath) + "\\($$##$$)"
                        + System.IO.Path.GetExtension(newFilePath);

                    File.WriteAllText(path, resultTextBox.Text);
                    File.Delete(newFilePath);
                    File.Move(path, newFilePath);
                }
                else
                {
                    File.WriteAllText(saveFileDialog.FileName, resultTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    $"Text converter can't save a file!\n{ex.Message}",
                    "Unexpected error!", MessageBoxButton.OK);
            }
        }

        private void langMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void aboutMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        private void parserButton_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string tag = button?.Tag.ToString();

            if (tag == htmlParserButton?.Tag.ToString() && !(builder is HtmlBuilder))
            {
                SetBuilder(ref builder, new HtmlBuilder());
            }
            else if (tag == markdownParserButton?.Tag.ToString() && !(builder is MarkdownBuilder))
            {
                SetBuilder(ref builder, new MarkdownBuilder());
            }

            HightlightButton(button, parserButtons);
        }

        private void SetBuilder(ref ConverterBuilder converterbuilder, ConverterBuilder newBuilder)
        {
            converterbuilder = newBuilder;

            // Horrible!
            // TODO: Change it to Resourses.GetString("save_filter" + builder.GetExtension());
            saveFileDialog.Filter = new Dictionary<string, string>
            {
                [".html"] = "HTML files (*.html)|*.html|Text files (*.txt)|*.txt",
                [".md"] = "Markdown files (*.md)|*.md|Text files (*.txt)|*.txt"
            }[builder.GetExtension()];

            saveFileDialog.FileName = null;
        }

        private void HightlightButton(Button buttonToHightlight, IEnumerable<Button> allButtons)
        {
            HightlightButton(buttonToHightlight, allButtons,
                Brushes.Coral, new SolidColorBrush(Color.FromRgb(221, 221, 221)));
        }

        private void HightlightButton(Button buttonToHightlight, IEnumerable<Button> allButtons,
            Brush brushToHighlight, Brush defaultBrush)
        {
            foreach (var button in allButtons)
            {
                button.Background = button == buttonToHightlight ? brushToHighlight : defaultBrush;
            }
        }

        private void mainTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: syntax highlighting
            // ...

            // Uncomment this when all builder's methods are implemented
            //resultTextBox.Text = parser.Parse(builder, (sender as TextBox)?.Text);

            // Just for tests
            resultTextBox.Text = (sender as TextBox)?.Text;
        }

    }
}
