using System.Collections.ObjectModel;
using System.Linq;
using TVShows.Data.Interfaces;

namespace TVShows.Data.Classes
{
    public class Administrator : Man, IAdministrator
    {
        private static ObservableCollection<Administrator> items = new ObservableCollection<Administrator>();

        public new static ObservableCollection<Administrator> Items
        {
            get { return items; }
            set { items = value; }
        }

        public static string Dtable = "Administrators";

        public static IRepository<Administrator> Repository { get; set; }
        
        public Administrator(){}

        public Administrator(string username, string password, string email)
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
            Id = Repository.GetId();
        }

        public override void Delete()
        {
            foreach (var favoriteAndAdmin in Favorites_and_admin.Items)
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
            new Favorites_and_admin(this, tvshow);
        }
    }
}
