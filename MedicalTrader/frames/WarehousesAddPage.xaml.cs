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
    /// Логика взаимодействия для WarehousesAddPage.xaml
    /// </summary>
    public partial class WarehousesAddPage : Page
    {
        public WarehousesAddPage()
        {
            InitializeComponent();

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
        }
    }
}
