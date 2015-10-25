using System;
using System.Collections.ObjectModel;
using System.Linq;
using TVShows.Data.Interfaces;

namespace TVShows.Data.Classes
{
    public class Favorites_and_admin : Base<Favorites_and_admin>
    {
        public static string Dtable = "Favorites_and_Admins";

        public int IdAdmin;
        public int IdTVShow;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdTVShow;
                objects[2] = IdAdmin;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdTVShow = (int)objects[1];
                IdAdmin = (int)objects[2];
            }
        }

        public IAdministrator AdminFavor
        {
            get { return Administrator.Get_obj(IdAdmin); }
            set { IdAdmin = value.Id; }
        }

        public ITvShow TvFavor
        {
            get { return Tvshow.Get_obj(IdTVShow); }
            set { IdTVShow = value.Id; }
        }

        public Favorites_and_admin(){}

        public Favorites_and_admin(IAdministrator admin, ITvShow tvshow)
        {
            AdminFavor = admin;
            TvFavor = tvshow;
            Save();
        }

        public static ObservableCollection<Favorites_and_admin> Init_favorites_and_admin()
        {
            Items = Repository.GetAllObjects();
            return Items;
        }

        public static bool Equals(IAdministrator admin, ITvShow tvshow)
        {
            return Items.Any(favoritesAndAdmin => favoritesAndAdmin.AdminFavor == admin && favoritesAndAdmin.TvFavor == tvshow);
        }
    }
}
