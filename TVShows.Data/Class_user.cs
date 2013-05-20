namespace TVShows.Data
{
    public class Class_user : Class_man
    {
        public static string Dtable = "Users";
        
        public Class_user(){}

        public Class_user(string username, string password, string email)
        {
            Name = username;
            Password = password;
            Email = email;
            Save(Dtable);
        }
    }
}
