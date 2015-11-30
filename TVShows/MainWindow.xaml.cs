using System.Windows;
using TVShows.Data;
using TVShows.Data.Classes;
using TVShows.Data.Interfaces;

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

        public Man Man;

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            Tvshow.Repository = new Access_repository<Tvshow>(Tvshow.Dtable);
            User.Repository = new Access_repository<User>(User.Dtable);
            Administrator.Repository = new Access_repository<Administrator>(Administrator.Dtable);
            Favorites_and_user.Repository = new Access_repository<Favorites_and_user>(Favorites_and_user.Dtable);
            Favorites_and_admin.Repository = new Access_repository<Favorites_and_admin>(Favorites_and_admin.Dtable);

            Tvshow.Init_tv_show();
            User.Init_user();
            Administrator.Init_administrator();
            Favorites_and_user.Init_favorites_and_user();
            Favorites_and_admin.Init_favorites_and_admin();

            var tvControl = UserControls.TVShowControl.Instance();
            Cap.Show_random_tv(tvControl);
            TVShowControl.Content = tvControl;
        }

        public void Log_in(Man man)
        {
            if (man.Name != null)
            {
                if (man.GetType() == typeof(Administrator))
                {
                    Cap.ComboAdd.Visibility = Visibility.Visible;
                    Cap.BtnUsers.Visibility = Visibility.Visible;
                    Cap.BtnFavorites.Visibility = Visibility.Visible;
                    Cap.BtnFavorites.IsEnabled = true;
                    Cap.BtnTVShows.Visibility = Visibility.Visible;
                    
                    Cap.TbLogin.Visibility = Visibility.Visible;
                    Cap.TbLogin.Text = "ADMIN: " + man.Name;
                }
                else
                {
                    Cap.BtnFavorites.Visibility = Visibility.Visible;
                    Cap.BtnFavorites.IsEnabled = true;

                    Cap.TbLogin.Visibility = Visibility.Visible;
                    Cap.TbLogin.Text = "Профиль: " + man.Name;
                }

                Man = man;

                Cap.BtnRegistration.IsEnabled = false;
                Cap.BtnLogin.IsEnabled = false;

                var control = UserControls.TVShowControl.Instance();
                Cap.Show_random_tv(control);

                TVDockPanelControl.Instance().Star.Visibility = Visibility.Visible;

                TVShowControl.Content = UserControls.TVShowControl.Instance();
            }
        }

        public void Log_out()
        {
            Cap.ComboAdd.Visibility = Visibility.Collapsed;
            Cap.BtnUsers.Visibility = Visibility.Collapsed;
            Cap.BtnFavorites.Visibility = Visibility.Collapsed;
            Cap.BtnFavorites.IsEnabled = false;
            Cap.TbLogin.Visibility = Visibility.Collapsed;
            Cap.BtnTVShows.Visibility = Visibility.Collapsed;
            Cap.BtnRegistration.IsEnabled = true;
            Cap.BtnLogin.IsEnabled = true;
            TVDockPanelControl.Instance().Star.Visibility = Visibility.Collapsed;
            Cap.BtnLogout.IsEnabled = false;

            Man = null;
        }
    }
}
