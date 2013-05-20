using System;
using System.Windows;
using TVShows.Data;

namespace TVShows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Main_window : Window
    {
        public Main_window()
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

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            var tvshow = new Class_tvshow();
            Class_tvshow.Items = tvshow.Get(Class_tvshow.Dtable);

            foreach (var tv in Class_tvshow.Items)
            {
                tv.Link_image = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + tv.Link_image;
            }

            var rand = new Random();
            var i = rand.Next(0, Class_tvshow.Items.Count);
            tvshow = Class_tvshow.Items[i];

            DataContext = tvshow;
        }
    }
}
