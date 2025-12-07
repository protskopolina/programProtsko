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

namespace _4._2_
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

            // Обробник для кнопки "Сховати"
            private void btnHide_Click(object sender, RoutedEventArgs e)
            {
                txtMessage.Visibility = Visibility.Collapsed; // або Visibility.Hidden
            }

            // Обробник для кнопки "Показати"
            private void btnShow_Click(object sender, RoutedEventArgs e)
            {
                txtMessage.Visibility = Visibility.Visible;
            }
        }
    }


