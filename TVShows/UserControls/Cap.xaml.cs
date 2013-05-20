﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TVShows
{
	/// <summary>
	/// Interaction logic for Cap.xaml
	/// </summary>
	public partial class Cap
	{
		public Cap()
		{
			InitializeComponent();
		}

        private void Autorisation_click(object sender, RoutedEventArgs e)
        {
            var control = new AutorisationContol();
            Navigation(control);
        }

        private void Home_click(object sender, RoutedEventArgs e)
        {
            var control = new RandomTVShowControl();
            Navigation(control);
        }

        private void Registration_click(object sender, RoutedEventArgs e)
        {
            var control = new RegistrationControl();
            Navigation(control);
        }

	    private void Users_view_click(object sender, RoutedEventArgs e)
        {
            var control = new UserViewContol();
            Navigation(control);
        }

        private void Favorites_click(object sender, RoutedEventArgs e)
        {
            var control = new FavoritesControl();
            Navigation(control);
        }

        private void Combo_add_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = ((ComboBoxItem)ComboAdd.SelectedItem);

            switch (currentItem.Name)
            {
                case "Add_user":
                    {
                        var addUser = new AddUserControl();
                        Navigation(addUser);
                    }
                    break;

                case "Add_tvshow":
                    {
                        var addTv = new AddTVControl();
                        Navigation(addTv);
                    }
                    break;

                case "Add_actor":
                {
                    var addActor = new AddMemberTeamContol { Title = { Text = "Добавить актера" } };
                    Navigation(addActor);
                }
                    break;

                case "Add_director": 
                    {
                        var addDirector = new AddMemberTeamContol { Title = { Text = "Добавить режиссера" } };
                        Navigation(addDirector);
                    }
                    break;
            }

        }
        
        private static void Navigation(UserControl control)
        {
            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.RandomTVShow.Content = control.Content;
        }
	}
}