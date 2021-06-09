using MedicalTrader.helpers;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        private DBWrapper db;
        private List<GrlpDrug> tempGrlp;
        private List<Drug> tempDrugs;
        public MedicalItemsPage()
        {
            InitializeComponent();
            db = new DBWrapper();

            tableDrugs.Items.Clear();
            tableDrugs.ItemsSource = db.Drugs.ToList();
            tableGRLSdrugs.Items.Clear();
            tableGRLSdrugs.ItemsSource = db.GrlpDrugs.ToList();

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
                var array = db.GrlpDrugs.ToArray();
                if (array.Length > 0) { db.GrlpDrugs.RemoveRange(array); }
                db.Database.ExecuteSqlCommand("UPDATE sqlite_sequence SET seq = 0 WHERE name = 'GrlpDrugs'");

                db.SaveChanges();
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
                db.GrlpDrugs.AddRange(result);
                db.SaveChanges();
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
            var chip = new MaterialDesignThemes.Wpf.Chip() { IsDeletable = true, Content = query };
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


                                if (obj.name.ToUpper().Contains(query.ToUpper()))
                                {
                                    ((Border)tableGRLSdrugsResults.Parent).Visibility = Visibility.Visible;


                                    tableGRLSdrugsResults.Items.Add((GrlpDrug)obj);


                                }

                            }

                            //tableGRLSdrugsResults.ItemsSource = temp;
                            break;

                        case "Номеру удостоверения":


                            foreach (GrlpDrug obj in tableGRLSdrugs.ItemsSource)
                            {


                                if (obj.certNumber.ToUpper().Contains(query.ToUpper()))

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
            tableGRLSdrugsResults.Items.Clear();
            tableGRLSdrugsResults.ItemsSource = null;
            ((Border)tableGRLSdrugsResults.Parent).Visibility = Visibility.Hidden;
            ;
            toolbarGrlp.Items.Remove(sender);

        }

        private void SearchForTableMedicalItems(object sender, RoutedEventArgs e)
        {
            string query = SearchField.Text;
            foreach (var item in tableDrugs.Items)
            {

                if (((ComboBoxItem)item).IsSelected)
                {
                    switch (((ComboBoxItem)item).Content)
                    {
                        case "Наименованию":


                            foreach (var obj in tableDrugs.Items)
                            {


                                if (((Drug)obj).nomenclature == query)
                                {
                                    tempDrugs = db.Drugs.ToList();
                                    var temp = new List<Drug>();
                                    temp.Add((Drug)obj);
                                    tableDrugs.ItemsSource = temp;
                                }

                            }


                            break;

                        case "Партии":

                            foreach (var obj in tableDrugs.Items)
                            {


                                if (((Drug)obj).party.ToString() == query)
                                {
                                    tempDrugs = db.Drugs.ToList();
                                    var temp = new List<Drug>();
                                    temp.Add((Drug)obj);
                                    tableDrugs.ItemsSource = temp;
                                }

                            }

                            break;

                        case "Серии":

                            foreach (var obj in tableDrugs.Items)
                            {


                                if (((Drug)obj).series.ToString() == query)
                                {
                                    tempDrugs = db.Drugs.ToList();
                                    var temp = new List<Drug>();
                                    temp.Add((Drug)obj);
                                    tableDrugs.ItemsSource = temp;
                                }

                            }

                            break;
                    }

                }
            }
        }





        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1");
        }
    }
}
