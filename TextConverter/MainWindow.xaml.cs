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
using TextConverter.Parser;
using System.Threading;
using System.Resources;


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
            Localize();
        }

        #region Initializators

        private void InitializeDialogs()
        {
            openFileDialog = new OpenFileDialog();
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
            openFileDialog.Filter = Properties.Resources.ResourceManager.GetString(ResourceKeys.OpenFileFilter);
            
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    saveFileDialog.FileName = null;
                    mainTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        $"{Properties.Resources.error_message_cant_open}\n{ex.Message}",
                        Properties.Resources.error_title, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void saveMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            string tag = menuItem?.Tag.ToString();
            string prevFilePath = saveFileDialog.FileName;
            saveFileDialog.Filter = Properties.Resources.ResourceManager.GetString(ResourceKeys.SaveFileFilter + builder.GetExtension());
            try
            {
                if (string.IsNullOrEmpty(prevFilePath) || tag == saveAsMenuItem?.Tag.ToString())
                {
                    if (saveFileDialog.ShowDialog() != true)
                        return;

                    if (string.Equals(saveFileDialog.FileName, prevFilePath, StringComparison.CurrentCultureIgnoreCase))
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
                else
                {
                    File.WriteAllText(saveFileDialog.FileName, resultTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    $"{Properties.Resources.error_message_cant_save}\n{ex.Message}",
                    Properties.Resources.error_title, MessageBoxButton.OK);
            }
        }

        private void langMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(((MenuItem)sender).Tag.ToString());
            Localize();

        }

        private void Localize()
        {
            var resourceManager = Properties.Resources.ResourceManager;

            openMenuItem.Header = resourceManager.GetString(ResourceKeys.Open);
            saveMenuItem.Header = resourceManager.GetString(ResourceKeys.Save);
            saveAsMenuItem.Header = resourceManager.GetString(ResourceKeys.SaveAs);
            labelConvert.Content = resourceManager.GetString(ResourceKeys.Convert);
            aboutMenuItem.Header = resourceManager.GetString(ResourceKeys.About);
            langMenuItem.Header = resourceManager.GetString(ResourceKeys.Languages);
            langEng.Header = resourceManager.GetString(ResourceKeys.LanguageEng);
            langRus.Header = resourceManager.GetString(ResourceKeys.LanguageRus);
        }

        private void aboutMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, Properties.Resources.about_message, Properties.Resources.about, MessageBoxButton.OK);
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
            UpdateConvertedText();
        }

        private void SetBuilder(ref ConverterBuilder converterbuilder, ConverterBuilder newBuilder)
        {
            converterbuilder = newBuilder;
            UpdateConvertedText();
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
            UpdateConvertedText();
        }

        private void UpdateConvertedText()
        {
            resultTextBox.Text = parser.Convert(builder.Clear(), mainTextBox?.Text);
        }

    }
}
