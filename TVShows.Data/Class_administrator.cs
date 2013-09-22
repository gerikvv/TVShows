using System.Collections.ObjectModel;

namespace TVShows.Data
{
    public class Class_administrator : Class_man
    {
        private static ObservableCollection<Class_administrator> items = new ObservableCollection<Class_administrator>();

        public new static ObservableCollection<Class_administrator> Items
        {
            get { return items; }
            set { items = value; }
        }

        public static string Dtable = "Administrators";
        
        public Class_administrator(){}

        public Class_administrator(string username, string password, string email)
        {
            Name = username;
            Password = password;
            Email = email;
            Save(Dtable);
        }

        public static void Init_administrator()
        {
            var admin = new Class_administrator();
            var collection = admin.Get(Dtable);
            foreach (var itemAdmin in collection)
                Items.Add((Class_administrator) itemAdmin);
        }
    }
}
