
using System.Windows;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
    

        }

        private void EditSelectedUser(object sender, RoutedEventArgs e)
        {

        }

        private void NavigateToUnitPage(object sender, RoutedEventArgs e)
        {
            SettingsFrame.Content = new UnitPage();
        }
        private void NavigateToUsersPage(object sender, RoutedEventArgs e)
        {
            SettingsFrame.Content = new UsersPage();
        }
    }
}
