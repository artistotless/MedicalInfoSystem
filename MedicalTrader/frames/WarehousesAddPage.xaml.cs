
using System.Linq;

using System.Windows;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для WarehousesAddPage.xaml
    /// </summary>
    public partial class WarehousesAddPage : Page
    {
        private WarehousesPage mainPage;
        public WarehousesAddPage(WarehousesPage page)
        {
            InitializeComponent();
            mainPage = page;
            var employee = DBConnector.Db().Users.ToList();
            foreach (var item in employee)
            {
                employeeList.Items.Add(item.fullName);
            }

            

            //Binding bind = new Binding();
            //  bind.Source = employee;
            //  bind.Path = new PropertyPath("id");
            //  employeeList.SetBinding(ComboBox.ItemsSourceProperty, bind);
            //employeeList.SetBinding(TextBlock.FontSizeProperty, bind);
        }

        private void SaveWarehouse(object sender, RoutedEventArgs e)
        {
            var name = this.name.Text;
            var region = this.region.Text;
            var adress = this.address.Text;
            var result = DBConnector.Db().Users.ToList().Where(x => x.fullName == employeeList.SelectedValue.ToString()).FirstOrDefault();
            int employee = result == null ? 0 : result.id;


            var newWh = new Warehouse(0, name, region, adress, employee);

            DBConnector.Db().Warehouses.Add(newWh);

            DBConnector.Db().SaveChanges();
            BackGroundEvents.HideLoading();
            mainPage.RefreshWarehouseTable();
        }
    }
}
