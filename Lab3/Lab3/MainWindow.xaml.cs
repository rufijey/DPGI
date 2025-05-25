using System;
using System.Windows;
using System.Windows.Controls;

namespace CurrencyConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConvertButton.IsEnabled = CurrencyComboBox.SelectedItem != null;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                string currency = (CurrencyComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                decimal rate = GetExchangeRate(currency);

                if (DirectionToUAH.IsChecked == true)
                {
                    decimal converted = amount * rate;
                    ResultTextBlock.Text = $"{amount} {currency} = {converted:F2} грн";
                }
                else if (DirectionFromUAH.IsChecked == true)
                {
                    decimal converted = amount / rate;
                    ResultTextBlock.Text = $"{amount} грн = {converted:F2} {currency}";
                }
                else
                {
                    MessageBox.Show("Оберіть напрямок конвертації.", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректну суму.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private decimal GetExchangeRate(string currency)
        {
            return currency switch
            {
                "USD" => 37.0m,
                "EUR" => 40.0m,
                "PLN" => 9.0m,
                _ => 1m
            };
        }

        private void CurrencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertButton.IsEnabled = CurrencyComboBox.SelectedItem != null;
        }

        private void DirectionToUAH_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
