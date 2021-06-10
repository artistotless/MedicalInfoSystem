using MaterialDesignThemes.Wpf;
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
            InitWhList();





        }
        void InitWhList()
        {
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
              new WarehousesAddPage(this)
              ).Show();
        }

        public void RefreshWarehouseTable(object sender = null, RoutedEventArgs e = null)
        {
            BackGroundEvents.ShowLoading("Обновление списка складов...");
            var whArray = DBConnector.Db().Warehouses.ToList();
            if (whArray.Count <= 0) { return; }
            whList.Children.Clear();
            InitWhList();
            BackGroundEvents.HideLoading();
        }

        private void SearchForTableWareHouses(object sender, RoutedEventArgs e)
        {
            var query = SearchField.Text;

            if (string.IsNullOrEmpty(query)) { return; }
            var chip = new Chip() { IsDeletable = true, Content = query };
            chip.DeleteClick += Chip_DeleteClick;
            toolbarWHs.Items.Add(chip);
            List<warehouseItem> willdeleted = new List<warehouseItem>();

            foreach (warehouseItem item in whList.Children)
            {
                var q = item.title.Text != null ? item.title.Text : string.Empty;
                if (!(q.ToUpper().Contains(query.ToUpper())))
                {
                    willdeleted.Add(item);

                }

            }
            foreach (var item in willdeleted)
            {
                whList.Children.Remove(item);
            }


        }






        private void Chip_DeleteClick(object sender, RoutedEventArgs e)
        {

            whList.Children.Clear();
            InitWhList();
            toolbarWHs.Items.Remove(sender);

            return;
        }


    }
}
