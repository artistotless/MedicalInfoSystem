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
    /// Логика взаимодействия для QuantityTypesPage.xaml
    /// </summary>
    public partial class UnitPage : Page
    {
        public UnitPage()
        {
            InitializeComponent();


            tableUnits.ItemsSource = DBConnector.Db().Units.ToList();
            tableUnits.InitializingNewItem += TableUnits_InitializingNewItem;
            tableUnits.CellEditEnding += TableUnits_CellEditEnding;


        }

        private void TableUnits_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {

                Unit newUnit = (Unit)e.Row.Item;
                var item = DBConnector.Db().Units.Find(newUnit.id);
                item.id = newUnit.id;
                item.name = newUnit.name;


            }
        }

        private void TableUnits_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {

            DBConnector.Db().Units.Add((Unit)e.NewItem);

        }



        private void RefreshUnits(object sender, RoutedEventArgs e)
        {
            BackGroundEvents.ShowLoading("Обновление таблицы..");
            if (DBConnector.Db().Units.ToList().Count <= 0) { return; }
            //tableDrugs.Items.Clear();
            tableUnits.ItemsSource = DBConnector.Db().Units.ToList();
            BackGroundEvents.HideLoading();
        }

        private void SaveUnits(object sender, RoutedEventArgs e)
        {
            DBConnector.Db().SaveChanges();
        }
    }
}
