using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TVShows
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
