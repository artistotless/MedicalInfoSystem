using MedicalTrader.uiElements;
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
    /// Логика взаимодействия для WarehousesPage.xaml
    /// </summary>
    public partial class WarehousesPage : Page
    {
        public WarehousesPage()
        {
            InitializeComponent();
            var storages = DBConnector.Db().Warehouses.ToList();

            foreach (var wh in storages)
            {
              
                whList.Children.Add(new warehouseItem(wh));
            }


        }

        private void AddNewWarehouse(object sender, RoutedEventArgs e)
        {
            new CustomWindow(
              new other.WindowConfig("Новый склад", 700, 550, ResizeMode.NoResize),
              new WarehousesAddPage()
              ).Show();
        }
    }
}
