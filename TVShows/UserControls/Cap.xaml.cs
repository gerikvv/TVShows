using System.Windows;
using System.Windows.Controls;
using TVShows.Data;

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
            var control = new TVShowControl();
            control.Random_tv();
            control.TbTitle.Text = "Случайный фильм";

            control.ArrowLeft.Visibility = Visibility.Visible;
            control.ArrowRigth.Visibility = Visibility.Visible;
            Navigation(control);
        }

        private void Registration_click(object sender, RoutedEventArgs e)
        {
            var control = new RegistrationControl();
            Navigation(control);
        }

	    private void Users_view_click(object sender, RoutedEventArgs e)
        {
            var control = UsersControl.Instance();
	        control.DataContext = new UserViewModel();
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
            mainWindow.RandomTVShow.Content = control;
        }

        private void Btn_logout_click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Log_out();

            var control = new TVShowControl();
            Navigation(control);
        }

        private void Btn_search_click(object sender, RoutedEventArgs e)
        {
            foreach (var tv in Class_tvshow.Items)
            {
                if (tv.Name.ToLower() == TbSearch.Text.ToLower())
                {
                    var control = new TVShowControl();
                    control.Color_rating(tv);
                    control.DataContext = tv;
                    control.TbTitle.Text = "Поиск";

                    control.ArrowLeft.Visibility = Visibility.Hidden;
                    control.ArrowRigth.Visibility = Visibility.Hidden;

                    Navigation(control);
                    return;
                }
            }
            TbSearch.Text = "Искомая комбинация слов не найдена.";
        }
	}
}