using MedicalTrader.helpers;
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
using System.Windows.Shapes;

namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
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
                //   new MainWindow(this, user).Show();
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
