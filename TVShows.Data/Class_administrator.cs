namespace TVShows.Data
{
    public class Class_administrator : Class_man
    {
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
                Items.Add(itemAdmin);
        }
    }
}
