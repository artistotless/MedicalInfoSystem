
using System.Linq;

using System.Windows;
using System.Windows.Controls;


namespace MedicalTrader
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            tableUsers.ItemsSource = DBConnector.Db().Users.ToList();
            tableUsers.InitializingNewItem += TableUsers_InitializingNewItem;
            tableUsers.CellEditEnding += TableUsers_CellEditEnding;


        }

        private void TableUsers_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {

                User newUser = (User)e.Row.Item;
                var item = DBConnector.Db().Users.Find(newUser.id);
                item.id = newUser.id;
                item.fullName = newUser.fullName;
                item.email = newUser.email;
                item.phone = newUser.phone;
                item.role = newUser.role;
                item.password = newUser.password;
                item.login = newUser.login;


            }
        }

        private void TableUsers_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {

            DBConnector.Db().Users.Add((User)e.NewItem);

        }



        private void RefreshUsers(object sender, RoutedEventArgs e)
        {
            BackGroundEvents.ShowLoading("Обновление таблицы..");
            if (DBConnector.Db().Users.ToList().Count <= 0) { BackGroundEvents.HideLoading(); return; }
            //tableDrugs.Items.Clear();
            tableUsers.ItemsSource = DBConnector.Db().Units.ToList();
            BackGroundEvents.HideLoading();
        }

        private void SaveUsers(object sender, RoutedEventArgs e)
        {
            DBConnector.Db().SaveChanges();
        }
    }
}
