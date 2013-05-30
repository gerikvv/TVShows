using System.Data;
using System.Windows;
using TVShows.Data;

namespace TVShows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Main_window : Window
    {
        public Main_window()
        {
            InitializeComponent();
        }

        public Class_man Man;

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            Class_tvshow.Init_tv_show();
            Class_user.Init_user();
            Class_administrator.Init_administrator();

            var control = new UserViewContol();
            RandomTVShow.Content = control.Content;

            Data_source = Get_data_set();
        }

        public DataSet Data_source { get; private set; }

        public static DataSet Get_data_set()
        {
            var dataSet = new DataSet();
            var dataTable = new DataTable("Users");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Password");
            dataTable.Columns.Add("Email");

            foreach (var user in Class_user.Items)
            {
                var dataRow = dataTable.NewRow();
                dataRow["ID"] = user.Id;
                dataRow["Name"] = user.Name;
                dataRow["Password"] = user.Password;
                dataRow["Email"] = user.Email;
                dataTable.Rows.Add(dataRow);
            }

            dataSet.Tables.Add(dataTable);
            return dataSet;
        }
        
        public void Log_in(Class_man man)
        {
            if (man.Name != null)
            {
                if (man.GetType() == typeof(Class_administrator))
                {
                    Cap.ComboAdd.Visibility = Visibility.Visible;
                    Cap.BtnUsersView.Visibility = Visibility.Visible;
                    Cap.BtnFavorites.Visibility = Visibility.Visible;

                    Cap.TbLogin.Visibility = Visibility.Visible;
                    Cap.TbLogin.Text = "ADMIN: " + man.Name;
                }
                else
                {
                    Cap.BtnFavorites.Visibility = Visibility.Visible;

                    Cap.TbLogin.Visibility = Visibility.Visible;
                    Cap.TbLogin.Text = "Профиль: " + man.Name;

                    Man = man;
                }
                Cap.BtnRegistration.IsEnabled = false;
                Cap.BtnLogin.IsEnabled = false;
            }
        }

        public void Log_out()
        {
            Cap.ComboAdd.Visibility = Visibility.Collapsed;
            Cap.BtnUsersView.Visibility = Visibility.Collapsed;
            Cap.BtnFavorites.Visibility = Visibility.Collapsed;
            Cap.TbLogin.Visibility = Visibility.Collapsed;
            Cap.BtnRegistration.IsEnabled = true;
            Cap.BtnLogin.IsEnabled = true;

            Man = null;
        }
    }
}
