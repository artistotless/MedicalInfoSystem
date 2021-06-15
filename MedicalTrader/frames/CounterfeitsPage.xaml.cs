using MedicalTrader.helpers;
using System.Windows;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для CounterfeitsPage.xaml
    /// </summary>
    public partial class CounterfeitsPage : Page
    {
        public CounterfeitsPage()
        {
            InitializeComponent();
        }

        private void UpdateRegistyCounterfeits(object sender, RoutedEventArgs e)
        {

        }

        private void SaveCounterfeitsTable(object sender, RoutedEventArgs e)
        {

        }

        private void SearchForRegisrtyCounterfeit(object sender, RoutedEventArgs e)
        {

        }


        private void SearchForCounterfeit(object sender, RoutedEventArgs e)
        {

            //string query = ta.Text;
            //if (string.IsNullOrEmpty(query)) { return; }
            //var chip = new Chip() { IsDeletable = true, Content = query };
            //chip.DeleteClick += Chip_DeleteClick;
            //toolbarGrlp.Items.Add(chip);


            //foreach (var item in grlpSearchType.Items)
            //{

            //    if (((ComboBoxItem)item).IsSelected)
            //    {
            //        switch (((ComboBoxItem)item).Content)
            //        {
            //            case "Наименованию":



            //                tableGRLSdrugsResults.Items.Clear();
            //                ((Border)tableGRLSdrugsResults.Parent).Visibility = Visibility.Visible;

            //                foreach (GrlsDrug obj in tableGRLSdrugs.ItemsSource)
            //                {

            //                    var q = obj.name != null ? obj.name : string.Empty;
            //                    if (!string.IsNullOrEmpty(q) && q.ToUpper().Contains(query.ToUpper()))
            //                    {


            //                        tableGRLSdrugsResults.Items.Add((GrlsDrug)obj);


            //                    }

            //                }


            //                break;

            //            case "Номеру удостоверения":
            //                tableGRLSdrugsResults.Items.Clear();
            //                ((Border)tableGRLSdrugsResults.Parent).Visibility = Visibility.Visible;

            //                foreach (GrlsDrug obj in tableGRLSdrugs.ItemsSource)
            //                {

            //                    var q = obj.certNumber != null ? obj.certNumber : string.Empty;

            //                    if (!string.IsNullOrEmpty(q) && q.ToUpper().Contains(query.ToUpper()))

            //                    {




            //                        tableGRLSdrugsResults.Items.Add((GrlsDrug)obj);


            //                    }

            //                }

            //                break;


            //        }

            //    }
            //}
        }

        private void NavigateToDrugsPage(object sender, RoutedEventArgs e)
        {
            NavigateFrame.NavigateToFrame(Pages.Drugs);
        }

        private void OpenAddCounterfeits(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshCounterfeitsTable(object sender, RoutedEventArgs e)
        {

        }

        private void SaveDTableCounterfeits(object sender, RoutedEventArgs e)
        {

        }

        private void SaveRegistryCounterfeitsTable(object sender, RoutedEventArgs e)
        {

        }
    }
}
