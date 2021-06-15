using MedicalTrader.helpers;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для ClientsAddPage.xaml
    /// </summary>
    public partial class ClientsAddPage : Page
    {

        private DataGrid mainDataGrid;
        public ClientsAddPage(DataGrid mainDataGrid)
        {
            InitializeComponent();
            this.mainDataGrid = mainDataGrid;
        }
        void InitUIByLicense(BuyerLicense license)
        {
            var data = license.data[0];
            companyName.Text = data.col3.label;
            this.license.Text = data.col1.label;
            address.Text = data.col5.label;
            if (
               string.IsNullOrEmpty(data.col17.label + data.col16.label + data.col14.label)
                ) { licenseFlag.Visibility = Visibility.Visible; }
            else { licenseFlag.Visibility = Visibility.Collapsed; }

        }

        private async void AutoFillClientBlank(object sender, RoutedEventArgs e)
        {
            var checker = new RosZdravNadzor();
            var license = await checker.GetLicenceAsync(inn.Text);
            if (license.data != null)
            {
                if (license.data.Count <= 0) { }
                else
                {
                    InitUIByLicense(license);
                }
            }


        }

        Client GetClientByFields(Client client)
        {

            client.companyName = this.companyName.Text;
            client.license = this.license.Text;
            client.licenseUrl = this.licenseUrl.Text;
            client.address = this.address.Text;
            client.contactFace = this.contactFace.Text;
            client.phone = this.phone.Text;
            client.inn = this.inn.Text;
            client.descr = this.descr.Text;

            //isEditMode = false;
            return client;
        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            BackGroundEvents.ShowLoading("Добавление нового клиента в БД...");

            DBConnector.Db().Clients.Add(GetClientByFields(new Client()));

            DBConnector.Db().SaveChanges();
            BackGroundEvents.ShowLoading("Обновление таблицы..");
            if (DBConnector.Db().Clients.ToList().Count <= 0) { return; }
            //tableDrugs.Items.Clear();
            mainDataGrid.ItemsSource = DBConnector.Db().Clients.ToList();
            BackGroundEvents.HideLoading();

        }
    }
}
