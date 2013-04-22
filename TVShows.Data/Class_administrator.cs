namespace TVShows.Data
{
    public class Class_administrator : Class_man
    {
        public static string Dtable = "Administrators";
        
        public Class_administrator(){}

        public Class_administrator(string name_user, string username, string password)
        {
            Name = name_user;
            Username = username;
            Password = password; 
            Save(Dtable);
        }
    }
}
