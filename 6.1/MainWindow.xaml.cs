using System;
using System.Windows;
using System.Windows.Controls;

namespace AuthSystem
{
    public partial class MainWindow : Window
    {
        private bool isPasswordVisible = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Перемикач вкладок
             private void LoginTab_Click(object sender, RoutedEventArgs e)
        {
            LoginForm.Visibility = Visibility.Visible;
            RegisterForm.Visibility = Visibility.Collapsed;

            LoginTabButton.Tag = "Visible";
            RegisterTabButton.Tag = "Collapsed";

            ClearMessages();
        }

        private void RegisterTab_Click(object sender, RoutedEventArgs e)
        {
            LoginForm.Visibility = Visibility.Collapsed;
            RegisterForm.Visibility = Visibility.Visible;

            LoginTabButton.Tag = "Collapsed";
            RegisterTabButton.Tag = "Visible";

            ClearMessages();
        }

        // Закриття вікна
  
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     
        // Показ / приховування пароля
    
        private void ShowPassword_Click(object sender, RoutedEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                // Створення текстбокса поверх PasswordBox
                var tb = new TextBox
                {
                    Text = LoginPasswordBox.Password,
                    Height = LoginPasswordBox.Height,
                    Padding = LoginPasswordBox.Padding,
                    BorderThickness = LoginPasswordBox.BorderThickness,
                    BorderBrush = LoginPasswordBox.BorderBrush
                };

                Grid parent = LoginPasswordBox.Parent as Grid;

                parent.Children.Remove(LoginPasswordBox);
                parent.Children.Add(tb);

                LoginPasswordBox = new PasswordBox(); // щоб не втратити посилання
                LoginShowPasswordButton.Content = "👁‍🗨";
            }
            else
            {
                // Ховаємо пароль назад
                var pb = new PasswordBox
                {
                    Password = "",
                    Height = 45,
                    Padding = new Thickness(40, 10, 40, 10)
                };

                Grid parent = LoginShowPasswordButton.Parent as Grid;

                parent.Children.Clear();
                parent.Children.Add(pb);
                parent.Children.Add(LoginShowPasswordButton);

                LoginPasswordBox = pb;
                LoginShowPasswordButton.Content = "👁";
            }
        }

        // Вхід в систему

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ClearMessages();

            string email = LoginEmailBox.Text.Trim();
            string password = LoginPasswordBox.Password.Trim();

            if (email == "" || password == "")
            {
                ShowLoginError("Будь ласка, заповніть всі поля.");
                return;
            }

            // Фейковий логін (тут можна підключити БД)
            if (email == "test@gmail.com" && password == "12345")
            {
                ShowLoginSuccess("Вхід виконано успішно!");
            }
            else
            {
                ShowLoginError("Невірний email або пароль.");
            }
        }

        // Реєстрація
            private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ClearMessages();

            string username = RegisterUsernameBox.Text.Trim();
            string email = RegisterEmailBox.Text.Trim();
            string phone = RegisterPhoneBox.Text.Trim();
            string pass = RegisterPasswordBox.Password.Trim();
            string confirm = RegisterConfirmPasswordBox.Password.Trim();

            if (username == "" || email == "" || phone == "" || pass == "" || confirm == "")
            {
                ShowRegisterError("Будь ласка, заповніть всі поля.");
                return;
            }

            if (pass != confirm)
            {
                ShowRegisterError("Паролі не співпадають.");
                return;
            }

            ShowRegisterSuccess("Користувач успішно зареєстрований!");
        }

             // Соцмережі
               private void GoogleLogin_Click(object sender, RoutedEventArgs e)
        {
            ShowLoginSuccess("Вхід через Google виконано.");
        }

        private void FacebookLogin_Click(object sender, RoutedEventArgs e)
        {
            ShowLoginSuccess("Вхід через Facebook виконано.");
        }

        private void TwitterLogin_Click(object sender, RoutedEventArgs e)
        {
            ShowLoginSuccess("Вхід через X.com виконано.");
        }

       
        // Допоміжні методи
         private void ClearMessages()
        {
            LoginMessagePanel.Visibility = Visibility.Collapsed;
            RegisterMessagePanel.Visibility = Visibility.Collapsed;
        }

        private void ShowLoginError(string message)
        {
            LoginMessageText.Text = message;
            LoginMessagePanel.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FEE2E2"));
            LoginMessageText.Foreground = System.Windows.Media.Brushes.DarkRed;
            LoginMessagePanel.Visibility = Visibility.Visible;
        }

        private void ShowLoginSuccess(string message)
        {
            LoginMessageText.Text = message;
            LoginMessagePanel.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#DCFCE7"));
            LoginMessageText.Foreground = System.Windows.Media.Brushes.Green;
            LoginMessagePanel.Visibility = Visibility.Visible;
        }

        private void ShowRegisterError(string message)
        {
            RegisterMessageText.Text = message;
            RegisterMessagePanel.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FEE2E2"));
            RegisterMessageText.Foreground = System.Windows.Media.Brushes.DarkRed;
            RegisterMessagePanel.Visibility = Visibility.Visible;
        }

        private void ShowRegisterSuccess(string message)
        {
            RegisterMessageText.Text = message;
            RegisterMessagePanel.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#DCFCE7"));
            RegisterMessageText.Foreground = System.Windows.Media.Brushes.Green;
            RegisterMessagePanel.Visibility = Visibility.Visible;
        }
    }
}
