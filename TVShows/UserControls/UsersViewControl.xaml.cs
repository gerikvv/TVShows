using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TVShows
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
            new ManipulatorViewModel((DataRowView) grid.SelectedItem);
        }
	}
}