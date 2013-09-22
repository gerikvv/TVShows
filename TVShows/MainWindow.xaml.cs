﻿using System.Windows;
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
            Class_favorites_and_user.Init_favorites_and_user();
            Class_favorites_and_admin.Init_favorites_and_admin();

            var tvControl = TVShowControl.Instance();
            Cap.Show_random_tv(tvControl);
            TVShowControl.Content = tvControl;
        }

        public void Log_in(Class_man man)
        {
            if (man.Name != null)
            {
                if (man.GetType() == typeof(Class_administrator))
                {
                    Cap.ComboAdd.Visibility = Visibility.Visible;
                    Cap.BtnUsers.Visibility = Visibility.Visible;
                    Cap.BtnFavorites.Visibility = Visibility.Visible;
                    Cap.BtnTVShows.Visibility = Visibility.Visible;
                    
                    Cap.TbLogin.Visibility = Visibility.Visible;
                    Cap.TbLogin.Text = "ADMIN: " + man.Name;
                }
                else
                {
                    Cap.BtnFavorites.Visibility = Visibility.Visible;

                    Cap.TbLogin.Visibility = Visibility.Visible;
                    Cap.TbLogin.Text = "Профиль: " + man.Name;
                }

                Man = man;

                Cap.BtnRegistration.IsEnabled = false;
                Cap.BtnLogin.IsEnabled = false;

                var control = TVShowControl.Instance();
                Cap.Show_random_tv(control);

                TVDockPanelControl.Instance().Star.Visibility = Visibility.Visible;

                TVShowControl.Content = TVShowControl.Instance();
            }
        }

        public void Log_out()
        {
            Cap.ComboAdd.Visibility = Visibility.Collapsed;
            Cap.BtnUsers.Visibility = Visibility.Collapsed;
            Cap.BtnFavorites.Visibility = Visibility.Collapsed;
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
