using System;
using System.Collections.ObjectModel;
using System.Linq;
using TVShows.Data.Interfaces;

namespace TVShows.Data
{
    public class Class_favorites_and_admin : Class_base<Class_favorites_and_admin>
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

        public IAdministrator Admin
        {
            get { return Class_administrator.Get_obj(IdAdmin); }
            set { IdAdmin = value.Id; }
        }

        public ITvShow Tvshow
        {
            get { return Class_tvshow.Get_obj(IdTVShow); }
            set { IdTVShow = value.Id; }
        }

        public Class_favorites_and_admin(){}

        public Class_favorites_and_admin(IAdministrator admin, ITvShow tvshow)
        {
            Admin = admin;
            Tvshow = tvshow;
            Save();
        }

        public static ObservableCollection<Class_favorites_and_admin> Init_favorites_and_admin()
        {
            Items = Repository.GetAllObjects();
            return Items;
        }

        public static bool Equals(IAdministrator admin, ITvShow tvshow)
        {
            return Items.Any(favoritesAndAdmin => favoritesAndAdmin.Admin == admin && favoritesAndAdmin.Tvshow == tvshow);
        }
    }
}
