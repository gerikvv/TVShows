using System.Data;
using System.Windows.Controls;
using TVShows.ViewModel;

namespace TVShows.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TVShowsViewControl.xaml
    /// </summary>
    public partial class TVShowsViewControl : UserControl
    {
        private static TVShowsViewControl tvShowViewControl;
        private TVShowsViewControl() { this.InitializeComponent(); }

        public static TVShowsViewControl Instance()
        {
            return tvShowViewControl ?? (tvShowViewControl = new TVShowsViewControl());
        }

        private void Grid_current_cell_changed(object sender, Syncfusion.Windows.ComponentModel.SyncfusionRoutedEventArgs args)
        {
            new TVShowManipulatorViewModel((DataRowView) grid.SelectedItem);
        }
    }
}
