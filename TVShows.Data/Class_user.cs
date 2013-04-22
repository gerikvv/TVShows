namespace TVShows.Data
{
    public class Class_user : Class_man
    {
        public static string Dtable = "Users";
        
        public Class_user(){}

        public Class_user(string name_user, string username, string password)
        {
            Name = name_user;
            Username = username;
            Password = password; 
            Save(Dtable);
        }
    }
}
