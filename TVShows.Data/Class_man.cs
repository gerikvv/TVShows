using System;

namespace TVShows.Data
{
    public class Class_man : Class_base<Class_man>
    {
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public override object[] Objparams
        {
            get
            {
                objects = new object[4];
                objects[0] = Id;
                objects[1] = Name;
                objects[2] = Password;
                objects[3] = Email;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                Name = (string)objects[1];
                Password = (string)objects[2];
                Email = (string)objects[3];
            }
        }

        public static string Login (string username_arg, string password_arg, out Class_man man)
        {
            if (username_arg != "" && password_arg != "")
            {
                foreach (var manItem in Items)
                {
                    if (manItem.Name == username_arg && manItem.Password == password_arg)
                    {
                        man = manItem;
                        return "";
                    }
                }
                { man = new Class_man(); return "Неправильная комбинация имени пользователя и пароля!"; }
            }
            man = new Class_man(); return "Все поля должны быть заполнены!";
        }

        protected static void Logout(string username_arg, string password_arg)
        {
        }

        protected static void View_information_tv_show(string name_tv_show)
        {
        }

        protected static void Search_tv_shows(params object[] list_params)
        {
        }
    }
}
