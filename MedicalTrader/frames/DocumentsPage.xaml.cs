
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для DocumentsPage.xaml
    /// </summary>
    public partial class DocumentsPage : Page
    {
        public DocumentsPage()
        {
            InitializeComponent();
            tableDocs.Items.Clear();
            tableDocs.ItemsSource = DBConnector.Db().Drugs.ToList();

        }

        private void OpenDocument(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start(Environment.CurrentDirectory + @"\" + @"offer_" + ((Button)sender).Tag.ToString() + ".docx");
            
        }

        private void RefreshClientsTable(object sender, System.Windows.RoutedEventArgs e)
        {
       
                BackGroundEvents.ShowLoading("Обновление таблицы..");
                if (DBConnector.Db().Documents.ToList().Count <= 0) { BackGroundEvents.HideLoading(); return; }
            //tableDrugs.Items.Clear();

            tableDocs.ItemsSource = DBConnector.Db().Documents.ToList();
                BackGroundEvents.HideLoading();
           

        }
    }
}
