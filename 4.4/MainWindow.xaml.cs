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

namespace _4._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Перетворюємо sender на кнопку
            var clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Ховаємо саму натиснуту кнопку
                clickedButton.Visibility = Visibility.Hidden;

                
                // Наприклад, якщо Button1 натиснули, ховаємо Button2 теж
                if (clickedButton == Button1 && Button2.Visibility == Visibility.Visible)
                    Button2.Visibility = Visibility.Hidden;
                else if (clickedButton == Button2 && Button3.Visibility == Visibility.Visible)
                    Button3.Visibility = Visibility.Hidden;
                else if (clickedButton == Button3 && Button4.Visibility == Visibility.Visible)
                    Button4.Visibility = Visibility.Hidden;
                else if (clickedButton == Button4 && Button5.Visibility == Visibility.Visible)
                    Button5.Visibility = Visibility.Hidden;

                // Перевірка, чи всі кнопки сховані
                if (Button1.Visibility == Visibility.Hidden &&
                    Button2.Visibility == Visibility.Hidden &&
                    Button3.Visibility == Visibility.Hidden &&
                    Button4.Visibility == Visibility.Hidden &&
                    Button5.Visibility == Visibility.Hidden)
                {
                    MessageBox.Show("Ви виграли! Всі кнопки приховані.");
                }
            }
        }
    }
}
