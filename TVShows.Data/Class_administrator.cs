using System.Collections.ObjectModel;
using System.Linq;
using TVShows.Data.Interfaces;

namespace TVShows.Data
{
    public class Class_administrator : Class_man, IAdministrator
    {
        private static ObservableCollection<Class_administrator> items = new ObservableCollection<Class_administrator>();

        public new static ObservableCollection<Class_administrator> Items
        {
            get { return items; }
            set { items = value; }
        }

        public static string Dtable = "Administrators";

        public static IRepository<Class_administrator> Repository { get; set; }
        
        public Class_administrator(){}

        public Class_administrator(string username, string password, string email)
        {
            Name = username;
            Password = password;
            Email = email;
            Save();
        }

        public static void Init_administrator()
        {
            Items = Repository.GetAllObjects();
        }

        public override void Save()
        {
            Repository.Save(this);
            Items.Add(this);
            Id = Repository.GetAllObjects().Last().Id;
        }

        public override void Delete()
        {
            foreach (var favoriteAndAdmin in Class_favorites_and_admin.Items)
            {
                if (favoriteAndAdmin.IdAdmin == Id)
                {
                    favoriteAndAdmin.Delete();
                    break;
                }
            }
            Items.Remove(this);
            Repository.Delete(Id);
        }

        public override void Update()
        {
            Repository.Update(this);
            if (!Items.Any(admin => admin.Id == Id)) return;
            Items[Items.IndexOf(Items.FirstOrDefault(elem => elem.Id == Id))] = this;
        }

        public new static IAdministrator Get_obj(int idObj)
        {
            return Items.FirstOrDefault(item => item.Id == idObj);
        }

        public override void AddFavoriteTv(ITvShow tvshow)
        {
            new Class_favorites_and_admin(this, tvshow);
        }
    }
}
