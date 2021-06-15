using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


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
            tableClients.Items.Clear();
            tableClients.ItemsSource = DBConnector.Db().Clients.ToList();
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
            BackGroundEvents.ShowLoading("Сохранение...");
            DBConnector.Db().SaveChanges();
            BackGroundEvents.HideLoading();
        }

        private void CreateOffer(object sender, RoutedEventArgs e)
        {
            new CustomWindow(
             new other.WindowConfig("Новый оффер", 750, 550),
             new OfferAddPage()
             ).Show();
        }

        private void RefreshClientsTable(object sender, RoutedEventArgs e)
        {
            BackGroundEvents.ShowLoading("Обновление таблицы..");
            if (DBConnector.Db().Clients.ToList().Count <= 0) { BackGroundEvents.HideLoading(); return; }
            //tableDrugs.Items.Clear();

            tableClients.ItemsSource = DBConnector.Db().Clients.ToList();
            BackGroundEvents.HideLoading();
        }


        private void SearchForTableClientsItems(object sender, RoutedEventArgs e)
        {
            string query = SearchField.Text;
            if (string.IsNullOrEmpty(query)) { return; }
            var chip = new Chip() { IsDeletable = true, Content = query };
            chip.DeleteClick += Chip_DeleteClick;
            toolbarClients.Items.Add(chip);
            tableClientsResults.Items.Clear();

            ((Border)tableClientsResults.Parent).Visibility = Visibility.Visible;

            foreach (Client obj in tableClients.ItemsSource)
            {
                var qName = !string.IsNullOrEmpty(obj.companyName) ? obj.companyName : string.Empty;
                var qDescr = !string.IsNullOrEmpty(obj.descr) ? obj.descr : string.Empty;
                var qInn = !string.IsNullOrEmpty(obj.inn) ? obj.inn : string.Empty;

                if (
                    qName.ToUpper().Contains(query.ToUpper()) ||
                    qDescr.ToUpper().Contains(query.ToUpper()) ||
                    qInn.ToUpper().Contains(query.ToUpper())
                    )
                {
                    tableClientsResults.Items.Add((Client)obj);
                }
            }
        }


        private void Chip_DeleteClick(object sender, RoutedEventArgs e)
        {

            tableClientsResults.Items.Clear();
            tableClientsResults.ItemsSource = null;
            ((Border)tableClientsResults.Parent).Visibility = Visibility.Hidden;
            toolbarClients.Items.Remove(sender);
            return;
        }


        private void RemoveSelectedClient(object sender, RoutedEventArgs e)
        {
            List<Client> tempArray = new List<Client>();
            var id = (int)(((Button)sender).DataContext);
            foreach (Client item in tableClients.Items)
            {
                tempArray.Add(item);
            }
            var willdeleted = tempArray.Where(x => x.id == id).Select(x => x).First();
            tempArray.Remove(willdeleted);
            //tableClients.Items.Remove(willdeleted);
            
            DBConnector.Db().Clients.Remove(willdeleted);
           
            DBConnector.Db().SaveChanges();
            tableClients.ItemsSource = DBConnector.Db().Clients.ToList();


        }
    }
}
