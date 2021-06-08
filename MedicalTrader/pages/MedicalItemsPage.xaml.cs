using MedicalTrader.helpers;
using System.Collections.Generic;
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
        public MedicalItemsPage()
        {
            InitializeComponent();
            db = new DBWrapper();

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
    }
}
