using System.Data;
using System.Windows.Controls;
using TVShows.ViewModel;

namespace TVShows.UserControls
{
	/// <summary>
	/// Interaction logic for UserViewContol.xaml
	/// </summary>
	public partial class UsersViewControl : UserControl
	{
        private static UsersViewControl userViewControl;
        private UsersViewControl() {this.InitializeComponent();}

		public static UsersViewControl Instance()
		{
		    return userViewControl ?? (userViewControl = new UsersViewControl());
		}

	    private void Grid_current_cell_changed(object sender, Syncfusion.Windows.ComponentModel.SyncfusionRoutedEventArgs args)
        {
            new UserManipulatorViewModel((DataRowView) grid.SelectedItem);
        }
	}
}