using System;
using System.Collections.ObjectModel;

namespace TVShows.Data
{
    public class Class_favorites_and_admin : Class_base<Class_favorites_and_admin>
    {
        public static string Dtable = "Favorites_and_Users";

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

        public Class_administrator Admin
        {
            get { return (Class_administrator) Class_administrator.Get_obj(IdAdmin); }
            set { IdAdmin = value.Id; }
        }

        public Class_tvshow Tvshow
        {
            get { return Class_tvshow.Get_obj(IdTVShow); }
            set { IdTVShow = value.Id; }
        }

        public Class_favorites_and_admin(Class_administrator admin, Class_tvshow tvshow)
        {
            Admin = admin;
            Tvshow = tvshow;
            Save(Dtable);
        }

        public Class_favorites_and_admin() { }

        public static ObservableCollection<Class_favorites_and_admin> Init_favorites_and_man()
        {
            var favoritesAndMan = new Class_favorites_and_admin();
            Items = favoritesAndMan.Get(Dtable);
            return Items;
        }
    }
}
