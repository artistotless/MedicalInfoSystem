using MaterialDesignThemes.Wpf;
using MedicalTrader.helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для MedicalItemsPage.xaml
    /// </summary>
    public partial class MedicalItemsPage : Page
    {


        public MedicalItemsPage()
        {
            InitializeComponent();
            tableDrugs.Items.Clear();
            tableDrugs.ItemsSource = DBConnector.Db().Drugs.ToList();
            tableGRLSdrugs.Items.Clear();
            tableGRLSdrugs.ItemsSource = DBConnector.Db().GrlpDrugs.ToList();
            tableDrugs.InitializingNewItem += TableDrugs_InitializingNewItem; ;
            tableDrugs.CellEditEnding += TableDrugs_CellEditEnding;

            Console.WriteLine();
        }

        //async void Test()
        //{
        //    await Task.Run(() => TestAsync());
        //}





        private void TableDrugs_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            DBConnector.Db().Drugs.Add((Drug)e.NewItem);

        }

        private void TableDrugs_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                Drug newItem = (Drug)e.Row.Item;
                var item = DBConnector.Db().Drugs.Find(newItem.id);
                item.manufacturer = newItem.manufacturer;
                item.nomenclature = newItem.nomenclature;
                item.party = newItem.party;
                item.price = newItem.price;
                item.quantity = newItem.quantity;
                item.series = newItem.series;
                item.warehouse = newItem.warehouse;



            }
        }

        public async Task ClearDBAsync()
        {

            await Task.Run(() => ClearDB());
        }
        private void ClearDB()
        {

            Dispatcher.Invoke(() =>
            {
                tableGRLSdrugs.ItemsSource = null;
                tableGRLSdrugs.Items.Clear();
                var array = DBConnector.Db().GrlpDrugs.ToArray();
                if (array.Length > 0) { DBConnector.Db().GrlpDrugs.RemoveRange(array); }
                DBConnector.Db().Database.ExecuteSqlCommand("UPDATE sqlite_sequence SET seq = 0 WHERE name = 'GrlpDrugs'");

                DBConnector.Db().SaveChanges();
            });






        }

        private async void UpdateGRLS(object sender, RoutedEventArgs e)
        {

            await ClearDBAsync();


            updateGRLSBtn.IsEnabled = false;
            string zipfile = await new GRLPService().DownloadGRLPAsync();
            string excelFile = await new ZipWrapper().UnzipAsync(zipfile, Settings.GRLP_PATH);
            var result = await new ExcelReader().ExcelToSqlAsync(excelFile);
            if (result != null)
            {
                int id = 1;
                foreach (var item in result)
                {
                    item.id = id;
                    id++;
                }
                DBConnector.Db().GrlpDrugs.AddRange(result);
                DBConnector.Db().SaveChanges();
                tableGRLSdrugs.ItemsSource = result;

                updateGRLSBtn.IsEnabled = true;
                BackGroundEvents.HideLoading();


            }
        }

        private async void OpenExcel_Click(object sender, RoutedEventArgs e)
        {
            BackGroundEvents.ShowLoading("Скачивается свежий каталог...");
            string zipfile = await new GRLPService().DownloadGRLPAsync();
            BackGroundEvents.ShowLoading("Распаковка архива...");
            string excelFile = await new ZipWrapper().UnzipAsync(zipfile, Settings.GRLP_PATH);
            BackGroundEvents.ShowLoading("Запуск Excel...");
            Process.Start(excelFile);
            BackGroundEvents.HideLoading();

        }

        private void SearchForTableGrlp(object sender, RoutedEventArgs e)
        {

            string query = grlpSearchField.Text;
            if (string.IsNullOrEmpty(query)) { return; }
            var chip = new Chip() { IsDeletable = true, Content = query };
            chip.DeleteClick += Chip_DeleteClick;
            toolbarGrlp.Items.Add(chip);


            foreach (var item in grlpSearchType.Items)
            {

                if (((ComboBoxItem)item).IsSelected)
                {
                    switch (((ComboBoxItem)item).Content)
                    {
                        case "Наименованию":



                            tableGRLSdrugsResults.Items.Clear();
                            foreach (GrlpDrug obj in tableGRLSdrugs.ItemsSource)
                            {

                                var q = obj.name != null ? obj.name : string.Empty;
                                if (!string.IsNullOrEmpty(q) && q.ToUpper().Contains(query.ToUpper()))
                                {
                                    ((Border)tableGRLSdrugsResults.Parent).Visibility = Visibility.Visible;


                                    tableGRLSdrugsResults.Items.Add((GrlpDrug)obj);


                                }

                            }


                            break;

                        case "Номеру удостоверения":
                            tableGRLSdrugsResults.Items.Clear();

                            foreach (GrlpDrug obj in tableGRLSdrugs.ItemsSource)
                            {

                                var q = obj.certNumber != null ? obj.certNumber : string.Empty;

                                if (!string.IsNullOrEmpty(q) && q.ToUpper().Contains(query.ToUpper()))

                                {


                                    ((Border)tableGRLSdrugsResults.Parent).Visibility = Visibility.Visible;


                                    tableGRLSdrugsResults.Items.Add((GrlpDrug)obj);


                                }

                            }

                            break;


                    }

                }
            }
        }

        private void Chip_DeleteClick(object sender, RoutedEventArgs e)
        {


            if (((ToolBar)((Chip)sender).Parent).Name == "toolbarDrugs")
            {

                tableDrugsResults.Items.Clear();
                tableDrugsResults.ItemsSource = null;
                ((Border)tableDrugsResults.Parent).Visibility = Visibility.Hidden;
                toolbarDrugs.Items.Remove(sender);

                return;
            }

            tableGRLSdrugsResults.Items.Clear();
            tableGRLSdrugsResults.ItemsSource = null;
            ((Border)tableGRLSdrugsResults.Parent).Visibility = Visibility.Hidden;
            toolbarGrlp.Items.Remove(sender);

        }

        private void SearchForTableMedicalItems(object sender, RoutedEventArgs e)
        {
            string query = SearchField.Text;
            if (string.IsNullOrEmpty(query)) { return; }
            var chip = new Chip() { IsDeletable = true, Content = query };
            chip.DeleteClick += Chip_DeleteClick;
            toolbarDrugs.Items.Add(chip);
            foreach (var item in SearchType.Items)
            {

                if (((ComboBoxItem)item).IsSelected)
                {
                    switch (((ComboBoxItem)item).Content)
                    {
                        case "Наименованию":



                            tableDrugsResults.Items.Clear();
                            foreach (Drug obj in tableDrugs.ItemsSource)
                            {
                                var q = obj.nomenclature != null ? obj.nomenclature : string.Empty;

                                if (!string.IsNullOrEmpty(q) && q.ToUpper().Contains(query.ToUpper()))
                                {
                                    ((Border)tableDrugsResults.Parent).Visibility = Visibility.Visible;


                                    tableDrugsResults.Items.Add((Drug)obj);


                                }

                            }


                            break;

                        case "Партии":
                            tableDrugsResults.Items.Clear();

                            foreach (Drug obj in tableDrugs.ItemsSource)
                            {


                                if (obj.party.ToString().ToUpper().Contains(query.ToUpper()))

                                {


                                    ((Border)tableDrugsResults.Parent).Visibility = Visibility.Visible;


                                    tableDrugsResults.Items.Add((Drug)obj);


                                }

                            }

                            break;

                        case "Серии":

                            tableDrugsResults.Items.Clear();
                            foreach (Drug obj in tableDrugs.ItemsSource)
                            {


                                if (obj.series.ToString().ToUpper().Contains(query.ToUpper()))

                                {


                                    ((Border)tableDrugsResults.Parent).Visibility = Visibility.Visible;


                                    tableDrugsResults.Items.Add((Drug)obj);


                                }

                            }

                            break;

                    }

                }
            }
        }

        private void SaveDrugsTable(object sender, RoutedEventArgs e)
        {
            BackGroundEvents.ShowLoading("Сохранение...");
            DBConnector.Db().SaveChanges();
            BackGroundEvents.HideLoading();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CustomWindow(
               new other.WindowConfig("Добавление медицинского препарата", 700, 550, ResizeMode.NoResize),
               new MedicalItemsAddPage(((Button)sender).DataContext.ToString())
               ).Show();
         

        }

        private void Invent_Click(object sender, RoutedEventArgs e)
        {

            BackGroundEvents.ShowLoading("Выгрузка в БД");
            List<string> farmGroupList = new List<string>();

            var grlp = DBConnector.Db().GrlpDrugs.ToList();
            int i = 1;
            foreach (var item in grlp)
            {
                if (item.farmGroups.Length <= 2)
                    continue;
                if (!farmGroupList.Contains(item.farmGroups))
                {
                    //farmGroupList.Add(item.farmGroups);
                    DBConnector.Db().FarmGroups.Add(new FarmGroup(i, item.farmGroups));
                }
                i++;
            }
            BackGroundEvents.ShowLoading("Сохранение в БД");
            DBConnector.Db().SaveChanges();




        }

        private void OpenAddDrugPage(object sender, RoutedEventArgs e)
        {
            new CustomWindow(
                new other.WindowConfig("Добавление медицинского препарата", 700, 550, ResizeMode.NoResize),
                new MedicalItemsAddPage()
                ).Show();
        }

        private void RefreshDrugsTable(object sender, RoutedEventArgs e)
        {
            BackGroundEvents.ShowLoading("Обновление таблицы..");
            if (DBConnector.Db().Drugs.ToList().Count <= 0) { return; }
            //tableDrugs.Items.Clear();
            tableDrugs.ItemsSource = DBConnector.Db().Drugs.ToList();
            BackGroundEvents.HideLoading();
        }
    }
}
