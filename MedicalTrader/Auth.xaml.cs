using MedicalTrader.helpers;

using System.Windows;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth(Window lastWindow = null)
        {

            InitializeComponent();
            if (lastWindow != null) { lastWindow.Close(); }
        }

        public Auth()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginField.Text) && !string.IsNullOrEmpty(passwordField.Password))
            {
                var user = AuthSystem.Login(loginField.Text, passwordField.Password);
                if (user != null)
                {
                    new MainWindow(this, user).Show();
                }
                else { MessageBox.Show("Введите валидный пароль и логин!"); }
            }
            else
            {
                MessageBox.Show("Введите валидный пароль и логин!");
            }



        }
    }
}
