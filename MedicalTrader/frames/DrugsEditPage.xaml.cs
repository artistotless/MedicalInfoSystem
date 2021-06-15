using System;
using System.Linq;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для MedicalItemsEditPage.xaml
    /// </summary>
    public partial class DrugsEditPage : Page
    {

        private DataGrid mainDataGrid;
        public DrugsEditPage()
        {
            InitializeComponent();

        }
        void initComboBox()
        {
            foreach (var item in DBConnector.Db().Warehouses.ToArray())
            {
                warehouse.Items.Add(item.name);
            }
        }
        public DrugsEditPage(int id, DataGrid dataGrid = null)
        {
            InitializeComponent();
            initComboBox();
            mainDataGrid = dataGrid;
            FillDrugFieldsFromBD(id);
            applyBtn.DataContext = id;
            titleBox.Text = "Редактирование";

      
        }

        Drug GetDrugByFields(Drug drug)
        {

            drug.nomenclature = this.name.Text;
            drug.price = Convert.ToInt32(this.price.Text);
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

        private void SaveDrug(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = DBConnector.Db().Drugs.Find((
                (int)((Button)sender).DataContext)
                );
            GetDrugByFields(item);
            DBConnector.Db().SaveChanges();
            mainDataGrid.ItemsSource = DBConnector.Db().Drugs.ToList();
        }


        private void AutoFillBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var grlp = DBConnector.Db().GrlpDrugs.ToList().Where(x => x.certNumber == certNumber.Text).FirstOrDefault();
            if (grlp == null) { return; }
            name.Text = grlp.name == null ? "" : grlp.name;
            country.Text = grlp.country == null ? "" : grlp.country;
            manufacturer.Text = grlp.certOwner == null ? "" : grlp.certOwner;
        }

        void FillDrugFieldsFromBD(int id)
        {
            var result = DBConnector.Db().Drugs.Where(x => x.id == id).FirstOrDefault();
            certNumber.Text = result.certNumber;
            available.Text = result.availableQuantity.ToString();
            name.Text = result.nomenclature;
            price.Text = result.price.ToString();
            manufacturer.Text = result.manufacturer;
            country.Text = result.country;
            expirationDate.Text = result.expirationDate;
            var wh = DBConnector.Db().Warehouses.ToList().Where(w => w.name == this.warehouse.Text).FirstOrDefault();
            warehouse.Text = wh != null ? wh.id.ToString() : "0";
            series.Text = result.series.ToString();
            quantity.Text = result.quantity.ToString();

        }
    }


}
