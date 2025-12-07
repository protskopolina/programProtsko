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



using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        private double lastNumber = 0;
        private string operation = string.Empty;
        private bool isOperationPerformed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обробка натискання цифр
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (isOperationPerformed)
            {
                txtDisplay.Text = "0";
                isOperationPerformed = false;
            }

            Button button = (Button)sender;
            string number = button.Content.ToString();

            if (txtDisplay.Text == "0")
                txtDisplay.Text = number;
            else
                txtDisplay.Text += number;
        }

        // Обробка операцій (+, -, *, /)
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string selectedOperation = button.Content.ToString();

            if (double.TryParse(txtDisplay.Text, out double currentNumber))
            {
                if (!string.IsNullOrEmpty(operation) && !isOperationPerformed)
                {
                    PerformCalculation();
                }
                else
                {
                    lastNumber = currentNumber;
                }

                operation = selectedOperation;
                isOperationPerformed = true;
            }
        }

        // Кнопка "="
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(operation))
            {
                PerformCalculation();
                operation = string.Empty;
                isOperationPerformed = true;
            }
        }

        // Виконання обчислень
        private void PerformCalculation()
        {
            if (double.TryParse(txtDisplay.Text, out double currentNumber))
            {
                switch (operation)
                {
                    case "+":
                        lastNumber = lastNumber + currentNumber;
                        break;
                    case "-":
                        lastNumber = lastNumber - currentNumber;
                        break;
                    case "*":
                        lastNumber = lastNumber * currentNumber;
                        break;
                    case "/":
                        if (currentNumber != 0)
                            lastNumber = lastNumber / currentNumber;
                        else
                        {
                            MessageBox.Show("Ділення на нуль неможливе!", "Помилка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                            Clear_Click(null, null);
                            return;
                        }
                        break;
                }

                txtDisplay.Text = lastNumber.ToString();
            }
        }

        // Крапка (десятковий роздільник)
        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (isOperationPerformed)
            {
                txtDisplay.Text = "0";
                isOperationPerformed = false;
            }

            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        // Очищення (C)
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            lastNumber = 0;
            operation = string.Empty;
            isOperationPerformed = false;
        }

        // Видалення останнього символу (Backspace)
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
            }
        }
    }
}