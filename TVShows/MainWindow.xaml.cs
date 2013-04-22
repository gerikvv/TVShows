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
    public partial class Main_window
    {
        public Main_window()
        {
            InitializeComponent();
        }

        private void Create_user_click(object sender, RoutedEventArgs e)
        {
            var user = new Class_user();
            Class_user.Items = user.Get(Class_user.Dtable);
            if (Class_user.Items.Count > 0)
            {
                user = (Class_user)Class_user.Items[0];
                user.Name = "tom";
                user.Update(Class_user.Dtable);
                user.Delete(Class_user.Dtable, user.Id);
            }

            //var dateTime = new DateTime(1969, 11, 13);
            //new Class_actor("Джерард Батлер", dateTime, "Пейсли, Шотландия, Великобритания", 43, "link");

            //var dateTime = new DateTime(1941, 2, 10);
            //new Class_director("Майкл Эптед", dateTime, "Олсбери, Букингемшир, Великобритания", 72, "link");

            //var admin = new Class_administrator();
            //Class_administrator.Items = admin.Get(Class_administrator.Dtable);

            new Class_user("gerik", "user1", "15042013");
            //new Class_administrator("gerik", "user1", "15042013");
        }
    }
}
