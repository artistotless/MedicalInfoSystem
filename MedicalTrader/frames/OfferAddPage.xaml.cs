
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для AddOfferPage.xaml
    /// </summary>
    public partial class OfferAddPage : Page
    {
        public OfferAddPage()
        {
            InitializeComponent();
            tableDrugs.Items.Clear();
            tableDrugs.ItemsSource = DBConnector.Db().Drugs.ToList();

            clientListInit();
        }

        private void clientListInit()
        {
            var clients = DBConnector.Db().Clients.ToList();
            foreach (var client in clients)
            {
                clientList.Items.Add(
                    new ComboBoxItem()
                    {
                        Content = client.companyName,
                        Tag = client.id
                    }
                    );

            }

        }

        private void Chip_DeleteClick(object sender, RoutedEventArgs e)
        {

            tableDrugsResults.Items.Clear();
            tableDrugsResults.ItemsSource = null;
            ((Border)tableDrugsResults.Parent).Visibility = Visibility.Collapsed;
            ((Border)tableDrugs.Parent).Visibility = Visibility.Visible;
            toolbarDrugs.Items.Remove(sender);

            return;

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

                            ((Border)tableDrugs.Parent).Visibility = Visibility.Collapsed;

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
                            ((Border)tableDrugs.Parent).Visibility = Visibility.Collapsed;

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

                            ((Border)tableDrugs.Parent).Visibility = Visibility.Collapsed;

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

        private void AddToOfferSelectedDrug(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = (Drug)((Button)sender).DataContext;
            int count = Convert.ToInt32(((Button)sender).Tag.ToString());
            item.quantity = count;
            tableOfferDrugs.Items.Add(item);
            // tableOfferDrugs.Items.Add(DBConnector.Db().Drugs.ToList().Where(x => x.id == idDrug).FirstOrDefault());

        }

        private void RemoveSelectedDrugFromOffer(object sender, System.Windows.RoutedEventArgs e)
        {
            List<Drug> tempArray = new List<Drug>();
            var idDrug = (int)(((Button)sender).DataContext);
            foreach (Drug item in tableOfferDrugs.Items)
            {
                tempArray.Add(item);
            }
            var willdeleted = tempArray.Where(x => x.id == idDrug).Select(x => x).First();
            // tempArray.Remove(willdeleted);
            //if(tableOfferDrugs.Items != null){
            //    if(tableOfferDrugs.Items.Count>0)
            //    tableOfferDrugs.Items.Clear();
            //

            tableOfferDrugs.Items.Remove(willdeleted);
            //tableOfferDrugs.ItemsSource = tempArray;
        }

        private void CreateOffer(object sender, System.Windows.RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            int idCLient = Convert.ToInt32(((ComboBoxItem)clientList.SelectedItem).Tag.ToString());
            var drugArray = new List<Drug>();
            foreach (Drug item in tableOfferDrugs.Items) { drugArray.Add(item); }
            string companyName = DBConnector.Db().Clients.Where(x => x.id == idCLient).FirstOrDefault().companyName;
            OfferDocument.PrintToWord(
                new DrugOffer(drugArray, companyName), (DBConnector.Db().Documents.Count()+1).ToString()
                );

            DBConnector.Db().Documents.Add(
                new Document(0, this.nameOffer.Text, "Оффер", "", DateTime.Today.ToString(), descrOffer.Text)
                );
            DBConnector.Db().SaveChanges();
            ((Button)sender).IsEnabled = true;

        }

        private void RefreshDrugsTable(object sender, RoutedEventArgs e)
        {

        }
    }
}

