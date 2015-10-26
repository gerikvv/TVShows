using System;
using TVShows.Data.Interfaces;

namespace TVShows.Data.Classes
{
    public class Man : Base<Man>, IMan
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

        public static string Login (string username_arg, string password_arg, out Man man)
        {
            if (username_arg != "" && password_arg != "")
            {
                foreach (var manItem in User.Items)
                {
                    if (manItem.Name == username_arg && manItem.Password == password_arg)
                    {
                        man = (Man) manItem;
                        return "";
                    }
                }
                foreach (var manItem in Administrator.Items)
                {
                    if (manItem.Name == username_arg && manItem.Password == password_arg)
                    {
                        man = manItem;
                        return "";
                    }
                }
                { man = new Man(); return "Неправильная комбинация имени пользователя и пароля!"; }
            }
            man = new Man(); return "Все поля должны быть заполнены!";
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

        public virtual void AddFavoriteTv(ITvShow tvshow) { }
    }
}
