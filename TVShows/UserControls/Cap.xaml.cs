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
            //var control = new TVShowControl
            //                  {
            //                      TbTitle = {Text = "Случайный фильм"},
            //                      ArrowLeft = {Visibility = Visibility.Visible},
            //                      ArrowRigth = {Visibility = Visibility.Visible}
            //                  };

            var control = TVShowControl.Instance();

            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Cap.Show_random_tv(control);
            if (mainWindow.Man != null) TVDockPanelControl.Instance().Star.Visibility = Visibility.Visible;
            Navigation(control);

            //control.PageTransitionControl.Show_page(tvDockPanelControl);
        }

	    public void Show_random_tv(TVShowControl control)
	    {
	        var tvDockPanelControl = TVDockPanelControl.Instance();
	        control.Random_tv(tvDockPanelControl);
	        control.PageTransitionControl.Show_page(tvDockPanelControl);
	    }

	    private void Registration_click(object sender, RoutedEventArgs e)
        {
            var control = new RegistrationControl();
            Navigation(control);
        }

	    private void Users_view_click(object sender, RoutedEventArgs e)
        {
            var control = UsersViewControl.Instance();
	        control.DataContext = new UserViewModel();
            Navigation(control);
        }

        private void Favorites_click(object sender, RoutedEventArgs e)
        {
            var control = new FavoritesControl();
            Navigation(control);
        }

        private void Tv_shows_click(object sender, RoutedEventArgs e)
        {
            var control = TVShowsViewControl.Instance();
            Navigation(control);
        }

        private void Combo_add_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = ((ComboBoxItem)ComboAdd.SelectedItem);

            switch (currentItem.Name)
            {
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
            TVShowControl.Instance().Content = control.Content;
        }

        private void Btn_logout_click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Log_out();

            var control = TVShowControl.Instance();
            Show_random_tv(control);
            Navigation(control);
        }

        private void Btn_search_click(object sender, RoutedEventArgs e)
        {
            foreach (var tv in Class_tvshow.Items)
            {
                if (tv.Name.ToLower() == TbSearch.Text.ToLower())
                {
                    var control = TVShowControl.Instance();
                    control.Color_rating(tv, TVDockPanelControl.Instance());
                    control.DataContext = tv;
                    control.TbTitle.Text = "Поиск";

                    control.ArrowLeft.Visibility = Visibility.Hidden;
                    control.ArrowRigth.Visibility = Visibility.Hidden;

                    var mainWindow = (Main_window)Application.Current.MainWindow;
                    if (mainWindow.Man != null) TVDockPanelControl.Instance().Star.Visibility = Visibility.Visible;

                    Navigation(control);
                    return;
                }
            }
            TbSearch.Text = "Искомая комбинация слов не найдена.";
        }
	}
}