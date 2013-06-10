using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
