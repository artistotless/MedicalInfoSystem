
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для warehouseInfo.xaml
    /// </summary>
    public partial class warehouseInfo : Page
    {
        public warehouseInfo(Warehouse wh)
        {
         
            var drugList = DBConnector.Db().Drugs.ToList().Where(d=>d.warehouse == wh.id);
            var resposibleUser = DBConnector.Db().Users == null ? null : DBConnector.Db().Users.Where(u => u.id == wh.employee).FirstOrDefault();

            InitializeComponent();

            titleWh.Text = "Название: " + wh.name;
            address.Text = "Адрес: " + wh.address;
            phone.Text = "Телефон: " + (resposibleUser != null ? resposibleUser.phone : "Телефон не найден");
            employee.Text = "Ответственный: " + (resposibleUser != null ? resposibleUser.fullName : "Пользователь не найден");
            region.Text = "Регион: " + wh.region;

            tableDrugs.Items.Clear();
            tableDrugs.ItemsSource = drugList;
        }
    }
}
