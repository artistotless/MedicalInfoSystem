
using System.Linq;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для MedicalItemsAddPage.xaml
    /// </summary>
    public partial class MedicalItemsAddPage : Page
    {
        public MedicalItemsAddPage()
        {
            InitializeComponent();
            initComboBox();
        }
        void initComboBox()
        {
            foreach (var item in DBConnector.Db().Warehouses.ToArray())
            {
                warehouse.Items.Add(item.name);
            }
        }
        public MedicalItemsAddPage(string certNumber)
        {
            InitializeComponent();
            initComboBox();
            this.certNumber.Text = certNumber;
            AutoFillBtn_Click(null, null);
        }

        private void SaveDrug(object sender, System.Windows.RoutedEventArgs e)
        {
            BackGroundEvents.ShowLoading("Добавление препарата в БД...");



            var name = this.name.Text;
            var manufacturer = this.manufacturer.Text;
            var country = this.country.Text;
            var expirationDate = this.expirationDate.Text;
            var wh = DBConnector.Db().Warehouses.ToList().Where(w => w.name == this.warehouse.Text).FirstOrDefault();
            var warehouse = wh != null ? wh.id : 0;
            var series = int.Parse((string.IsNullOrEmpty(this.series.Text) ? "0" : this.series.Text));
            var quantity = int.Parse((string.IsNullOrEmpty(this.quantity.Text) ? "0" : this.quantity.Text));
            var available = int.Parse((string.IsNullOrEmpty(this.available.Text) ? "0" : this.available.Text));
            var certNumber = this.certNumber.Text;

            var newDrug = new Drug(0, name, manufacturer, country, expirationDate, warehouse, series, quantity, available, certNumber);

            DBConnector.Db().Drugs.Add(newDrug);

            DBConnector.Db().SaveChanges();
            BackGroundEvents.HideLoading();

        }

        private void AutoFillBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var grlp = DBConnector.Db().GrlpDrugs.ToList().Where(x => x.certNumber == certNumber.Text).FirstOrDefault();
            if (grlp == null) { return; }
            name.Text = grlp.name == null ? "" : grlp.name;
            country.Text = grlp.country == null ? "" : grlp.country;
            manufacturer.Text = grlp.certOwner == null ? "" : grlp.certOwner;
        }


    }
}
