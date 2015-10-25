using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TVShows.Data.Interfaces;

namespace TVShows.Data.Classes
{
    public class User : Man, IUser
    {
        private static ObservableCollection<User> items = new ObservableCollection<User>();

        public new static ObservableCollection<User> Items
        {
            get { return items; }
            set { items = value; }
        }

        public static string Dtable = "Users";

        public static IRepository<User> Repository { get; set; }
        
        public User(){}

        public User(string username, string password, string email)
        {
            Name = username;
            Password = password;
            Email = email;
            Save();
        }

        public static string Registration(string login, string pass1, string pass2, string email, out Man man)
        {
            if (login != "" & pass1 != "" & pass2 != "" & email != "")
            {
                if (pass1 == pass2)
                {
                    if (login.Length > 3 & pass1.Length > 3)
                    {
                        var user = new User {Name = login, Password = pass1, Email = email};

                        if (Items.Count > 0)
                        {
                            foreach (var item in Items)
                            {
                                if (item.Name == login && item.Password == pass1 && item.GetType() == typeof(Administrator))
                                {
                                    Login(login, pass1, out man);
                                    return "";
                                }

                                if (user.Name == item.Name)
                                {
                                    man = new Man();
                                    return "Такой пользователь уже существует!";
                                }

                                if (user.Email == item.Email)
                                {
                                    man = new Man();
                                    return "Такой email-адресс уже ипользуется!";
                                }
                            }
                        }
                        user.Save();
                    }
                    else { man = new Man(); return "Длина имени и пароля должна быть больше 4 символов!"; }
                }
                else { man = new Man(); return "Пароли должны совпадать!"; }
            }
            else { man = new Man(); return "Все поля должны быть заполнены!"; }
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
            foreach (var favoriteAndUser in Favorites_and_user.Items)
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
            new Favorites_and_user(this, tvshow);
        }
    }
}
