using System.Data;

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

        public static string Registration(string login, string pass1, string pass2, string email, out Class_man man)
        {
            if (login != "" & pass1 != "" & pass2 != "" & email != "")
            {
                if (pass1 == pass2)
                {
                    if (login.Length > 3 & pass1.Length > 3)
                    {
                        var user = new Class_user {Name = login, Password = pass1, Email = email};

                        if (Items.Count > 0)
                        {
                            foreach (var item in Items)
                            {
                                if (item.Name == login && item.Password == pass1 && item.GetType() == typeof(Class_administrator))
                                {
                                    Login(login, pass1, out man);
                                    return "";
                                }

                                if (user.Name == item.Name)
                                {
                                    man = new Class_man();
                                    return "Такой пользователь уже существует!";
                                }

                                if (user.Email == item.Email)
                                {
                                    man = new Class_man();
                                    return "Такой email-адресс уже ипользуется!";
                                }
                            }
                        }
                        user.Save(Dtable);
                        Items.Add(user);
                    }
                    else { man = new Class_man(); return "Длина имени и пароля должна быть больше 4 символов!"; }
                }
                else { man = new Class_man(); return "Пароли должны совпадать!"; }
            }
            else { man = new Class_man(); return "Все поля должны быть заполнены!"; }
            Login(login, pass1, out man);
            return "Регистрация прошла успешно!";
        }

        public static void Init_user()
        {
            var user = new Class_user();
            var collection = user.Get(Dtable);
            foreach (var itemUser in collection)
                Items.Add(itemUser);
        }

        protected override void RaisePropertyChanged(string property_name)
        {
            base.RaisePropertyChanged(property_name);
            if (State == ConnectionState.Closed && Name != null && Password != null && Email != null)
                Update(Dtable);
        }
    }
}
