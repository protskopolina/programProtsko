using System.Windows;
using System.Windows.Controls;

namespace лаб5._2
{
    public partial class MainWindow : Window
    {
        double fuelPrice = 49.50;
        double fuelResult = 0;

        public MainWindow()
        {
            InitializeComponent();
            tbPrice.Text = fuelPrice.ToString("F2");

            rbLiters.Checked += rbLiters_Checked;
            rbSum.Checked += rbSum_Checked;
        }

        // === ВИБІР ПАЛЬНОГО ===
        private void cbFuel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((cbFuel.SelectedItem as ComboBoxItem).Content.ToString())
            {
                case "A-92": fuelPrice = 49.50; break;
                case "A-95": fuelPrice = 52.20; break;
                case "Дизель": fuelPrice = 46.80; break;
            }

            tbPrice.Text = fuelPrice.ToString("F2");
            RecalculateFuel();
        }

        // === ЛОГІКА РАДІОКНОПОК ===
        private void rbLiters_Checked(object sender, RoutedEventArgs e)
        {
            lblResultHeader2.Content = "До оплати:";
            tbInput.Text = "";
            RecalculateFuel();
        }

        private void rbSum_Checked(object sender, RoutedEventArgs e)
        {
            lblResultHeader2.Content = "Літри:";
            tbInput.Text = "";
            RecalculateFuel();
        }

        // === ВВЕДЕННЯ ДАНИХ ПАЛЬНОГО ===
        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            RecalculateFuel();
        }

        private void RecalculateFuel()
        {
            if (!double.TryParse(tbInput.Text, out double value))
            {
                tbResult.Text = "";
                fuelResult = 0;
                return;
            }

            if (rbLiters.IsChecked == true)
            {
                fuelResult = value * fuelPrice;
                tbResult.Text = fuelResult.ToString("F2") + " грн";
            }
            else
            {
                fuelResult = value;
                double liters = value / fuelPrice;
                tbResult.Text = liters.ToString("F2") + " л";
            }
        }

        // === МІНІ-КАФЕ ===
        private void cbCafe_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb == cbHotdog) tbHotdogQty.IsEnabled = cbHotdog.IsChecked == true;
            if (cb == cbBurger) tbBurgerQty.IsEnabled = cbBurger.IsChecked == true;
            if (cb == cbCola) tbColaQty.IsEnabled = cbCola.IsChecked == true;
            if (cb == cbCoffee) tbCoffeeQty.IsEnabled = cbCoffee.IsChecked == true;
        }

        private double CalculateCafe()
        {
            double sum = 0;

            if (cbHotdog.IsChecked == true && double.TryParse(tbHotdogQty.Text, out double q1))
                sum += q1 * 40;

            if (cbBurger.IsChecked == true && double.TryParse(tbBurgerQty.Text, out double q2))
                sum += q2 * 55;

            if (cbCola.IsChecked == true && double.TryParse(tbColaQty.Text, out double q3))
                sum += q3 * 30;

            if (cbCoffee.IsChecked == true && double.TryParse(tbCoffeeQty.Text, out double q4))
                sum += q4 * 25;

            return sum;
        }

        // === ПІДСУМОК ===
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            double total = 0;

            double cafe = CalculateCafe();
            double fuel = rbLiters.IsChecked == true ? fuelResult : fuelResult;

            total = cafe + fuel;

            tbTotal.Text = total.ToString("F2") + " грн";
        }
    }
}
