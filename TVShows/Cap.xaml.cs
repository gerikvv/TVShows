using System;
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
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("Autorisation.xaml", UriKind.Relative));
        }

        private void Home_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }

        private void Registration_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("Registration.xaml", UriKind.Relative));
        }

        private void Users_view_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("UsersView.xaml", UriKind.Relative));
        }

        private void Favorites_click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);
            if (service != null) service.Navigate(new Uri("Favorites.xaml", UriKind.Relative));
        }

        private void Combo_add_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = ((ComboBoxItem)ComboAdd.SelectedItem);

            var service = NavigationService.GetNavigationService(this);
            switch (currentItem.Name)
            {
                case "Add_user": if (service != null) service.Navigate(new Uri("AddUser.xaml", UriKind.Relative));
                    break;
                case "Add_tvshow": if (service != null) service.Navigate(new Uri("AddTV.xaml", UriKind.Relative));
                    break;

                case "Add_actor": if (service != null)
                {
                    var addActor = new AddMemberTeam {Title = {Text = "Добавить актера"}};
                    service.Navigate(addActor);
                }
                    break;

                case "Add_director": if (service != null)
                    {
                        var addDirector = new AddMemberTeam { Title = { Text = "Добавить режиссера" } };
                        service.Navigate(addDirector);
                    }
                    break;
            }

        }
	}
}