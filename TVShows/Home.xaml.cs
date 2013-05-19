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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TVShows.Data;

namespace TVShows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Create_user_click(object sender, RoutedEventArgs e)
        {
            //var user = new Class_user();
            //Class_user.Items = user.Get(Class_user.Dtable);
            //if (Class_user.Items.Count > 0)
            //{
            //    user = (Class_user)Class_user.Items[0];
            //    user.Name = "tom";
            //    user.Update(Class_user.Dtable);
            //    user.Delete(Class_user.Dtable, user.Id);
            //}

            var dateTime = new DateTime(1969, 11, 13);
            var actor = new Class_actor("Джерард Батлер", dateTime, "Пейсли, Шотландия, Великобритания", 43, "link");

            var genre = new Class_genre("Фантастика");

            new Class_actor_and_genre(actor, genre);

            //var dateTime = new DateTime(1941, 2, 10);
            //new Class_director("Майкл Эптед", dateTime, "Олсбери, Букингемшир, Великобритания", 72, "link");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var tvshow = new Class_tvshow();
            Class_tvshow.Items = tvshow.Get(Class_tvshow.Dtable);
        }
    }
}
