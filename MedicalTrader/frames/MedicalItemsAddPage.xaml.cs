
using System.Linq;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для MedicalItemsAddPage.xaml
    /// </summary>
    public partial class MedicalItemsAddPage : Page
    {
        private DataGrid mainDataGrid;
     

        // Добавление препарата вручную
        public MedicalItemsAddPage(DataGrid dataGrid = null)
        {
            mainDataGrid = dataGrid;
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



        Drug GetDrugByFields(Drug drug)
        {

            drug.nomenclature = this.name.Text;
            drug.manufacturer = this.manufacturer.Text;
            drug.country = this.country.Text;
            drug.expirationDate = this.expirationDate.Text;
            var wh = DBConnector.Db().Warehouses.ToList().Where(w => w.name == this.warehouse.Text).FirstOrDefault();
            drug.warehouse = wh != null ? wh.id : 0;
            drug.series = int.Parse((string.IsNullOrEmpty(this.series.Text) ? "0" : this.series.Text));
            drug.quantity = int.Parse((string.IsNullOrEmpty(this.quantity.Text) ? "0" : this.quantity.Text));
            var temp = int.Parse((string.IsNullOrEmpty(available.Text) ? "0" : available.Text));

            drug.availableQuantity = int.Parse((string.IsNullOrEmpty(available.Text) ? "0" : available.Text));
            drug.certNumber = this.certNumber.Text;
            //isEditMode = false;
            return drug;
        }
        // Добавление препарата из ГРЛС
        public MedicalItemsAddPage(string certNumber, DataGrid dataGrid = null)
        {
            InitializeComponent();
            initComboBox();
            mainDataGrid = dataGrid;
            this.certNumber.Text = certNumber;
            AutoFillBtn_Click(null, null);
            //isEditMode = false;
        }

        // Редактирование препарата
      

        private void AddDrug(object sender, System.Windows.RoutedEventArgs e)
        {
  
            BackGroundEvents.ShowLoading("Добавление препарата в БД...");

            DBConnector.Db().Drugs.Add(GetDrugByFields(new Drug()));

            DBConnector.Db().SaveChanges();
            BackGroundEvents.ShowLoading("Обновление таблицы..");
            if (DBConnector.Db().Drugs.ToList().Count <= 0) { return; }
            //tableDrugs.Items.Clear();
            mainDataGrid.ItemsSource = DBConnector.Db().Drugs.ToList();
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
