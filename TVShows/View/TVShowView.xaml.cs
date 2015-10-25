using System.Windows;
using TVShows.ViewModel;

namespace TVShows.View
{
    /// <summary>
    /// Логика взаимодействия для TVShowsView.xaml
    /// </summary>
    public partial class TVShowView : Window
    {
        public TVShowView(TVShowManipulatorViewModel view_model)
        {
            InitializeComponent();
            this.DataContext = view_model;
        }

        private void Btn_save(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
