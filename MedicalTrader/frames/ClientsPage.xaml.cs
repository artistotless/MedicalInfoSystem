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

namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void OpenDialogToAddNewClient(object sender, RoutedEventArgs e)
        {
            new CustomWindow(
            new other.WindowConfig("Новый клиент", 700, 550, ResizeMode.NoResize),
            new ClientsAddPage(tableClients)
            ).Show();
        }

        private void SaveClientTable(object sender, RoutedEventArgs e)
        {

        }

        private void CreateOffer(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshClientsTable(object sender, RoutedEventArgs e)
        {

        }

        private void SearchForTableClientsItems(object sender, RoutedEventArgs e)
        {

        }

        private void EditSelectedClient(object sender, RoutedEventArgs e)
        {

        }
    }
}
