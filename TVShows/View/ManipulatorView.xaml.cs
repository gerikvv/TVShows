using System.Windows;
using System.Windows.Controls;

namespace TVShows
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ManipulatorView : Window
    {
        public ManipulatorView(ManipulatorViewModel view_model)
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
