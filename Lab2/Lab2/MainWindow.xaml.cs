using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        private string _copiedText = "";

        public MainWindow()
        {
            InitializeComponent();
            fontSlider.ValueChanged += FontSlider_ValueChanged;
        }

        // Слайдер шрифта
        private void FontSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mainTextBox != null)
                mainTextBox.FontSize = fontSlider.Value;
        }

        // Открыть файл
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFile.ShowDialog() == true)
            {
                mainTextBox.Text = File.ReadAllText(openFile.FileName);
            }
        }

        // Очистить текст
        private void ClearText_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Clear();
        }

        // Копировать
        private void CopyText_Click(object sender, RoutedEventArgs e)
        {
            _copiedText = mainTextBox.SelectedText;
            Clipboard.SetText(_copiedText);
        }

        // Вставить
        private void PasteText_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                int caret = mainTextBox.CaretIndex;
                mainTextBox.Text = mainTextBox.Text.Insert(caret, Clipboard.GetText());
                mainTextBox.CaretIndex = caret + Clipboard.GetText().Length;
            }
        }

        // OK-кнопка (например, показать сообщение)
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK натиснуто!", "Повідомлення");
        }

        private void mainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
