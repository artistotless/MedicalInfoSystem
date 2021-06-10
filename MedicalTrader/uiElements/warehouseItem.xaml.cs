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

namespace MedicalTrader.uiElements
{
    /// <summary>
    /// Логика взаимодействия для warehouseItem.xaml
    /// </summary>
    public partial class warehouseItem : UserControl
    {
        private Warehouse warehouse;
        // private UserControl parent;
        public warehouseItem(Warehouse warehouse)
        {
            InitializeComponent();
            title.Text = warehouse.name;
            address.Text = warehouse.address;
            this.warehouse = warehouse;

        }

        private void DeleteWareHouse_Click(object sender, RoutedEventArgs e)
        {
            DBConnector.Db().Warehouses.Remove(warehouse);
            DBConnector.Db().SaveChanges();
            ((WrapPanel)Parent).Children.Remove(this);
        }

        private void ShowInfo(object sender, RoutedEventArgs e)
        {
            new CustomWindow(
                new other.WindowConfig("Информация о складе", 800,550, ResizeMode.CanMinimize),
                new warehouseInfo(warehouse)
                ).Show();

        }
    }
}
