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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            table.ItemsSource = initDrugs();

        }
        public List<Drug> initDrugs()
        {
            //int id, string manufacturer, string country, string expirationDate, Warehouse warehouse, int series, int quantity, int availableQuantity
            Drug[] drugs = {
                new Drug(1,"Строфантин® К", "АО Галичфарм","Украина","04.2023",new Warehouse("Основной склад 1"),1,400,390),
                new Drug(2,"Рузам концентрат", "Рузам-М ООО","Россия","04.2023",new Warehouse("Основной склад 1"),1,500,500),
                new Drug(3,"Анальгин", "Синтез ОАО","Россия","04.2023",new Warehouse("Основной склад 1"),1,400,390),
                new Drug(4,"Ксероформ", "Асфарма ОАО","Россия","04.2023",new Warehouse("Основной склад 2"),1,400,390),
                new Drug(5,"Левомицетин", "Органика ОАО","Россия","04.2023",new Warehouse("Основной склад 2"),1,400,390),
                new Drug(6,"Метазид", "Усолье-Сибирский химфармкомбинат ОАО","Россия","04.2023",new Warehouse("Основной склад 1"),1,400,390),

            };
            
            return new List<Drug>(drugs);
        }
        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
