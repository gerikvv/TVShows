using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TVShows.Data.Interfaces;

namespace TVShows.Data
{
    public class Class_user : Class_man, IUser
    {
        private static ObservableCollection<Class_user> items = new ObservableCollection<Class_user>();

        public new static ObservableCollection<Class_user> Items
        {
            get { return items; }
            set { items = value; }
        }

        public static string Dtable = "Users";

        public static IRepository<Class_user> Repository { get; set; }
        
        public Class_user(){}

        public Class_user(string username, string password, string email)
        {
            Name = username;
            Password = password;
            Email = email;
            Save();
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
                        user.Save();
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
            Items = Repository.GetAllObjects();
        }

        protected override void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
            if (!Items.Any(user => user.Id == Id)) return;
            if (Repository.State == ConnectionState.Closed && Name != null && Password != null && Email != null)
                Update();
        }

        public override void Save()
        {
            Repository.Save(this);
            Items.Add(this);
            Id = Repository.GetAllObjects().Last().Id;
        }

        public override void Delete()
        {
            foreach (var favoriteAndUser in Class_favorites_and_user.Items)
            {
                if (favoriteAndUser.IdUser == Id)
                {
                    favoriteAndUser.Delete();
                    break;
                }
            }
            Items.Remove(this);
            Repository.Delete(Id);
        }

        public override void Update()
        {
            Repository.Update(this);
            Items[Items.IndexOf(Items.FirstOrDefault(elem => elem.Id == Id))] = this;
        }

        public new static IUser Get_obj(int idObj)
        {
            return Items.FirstOrDefault(item => item.Id == idObj);
        }

        public override void AddFavoriteTv(ITvShow tvshow)
        {
            new Class_favorites_and_user(this, tvshow);
        }
    }
}
