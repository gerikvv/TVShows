using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TVShows.Data
{
    public class Class_favorites_and_user : Class_base<Class_favorites_and_user>
    {
        public static string Dtable = "Favorites_and_Users";

        public int IdUser;
        public int IdTVShow;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdTVShow;
                objects[2] = IdUser;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdTVShow = (int)objects[1];
                IdUser = (int)objects[2];
            }
        }

        public Class_user User
        {
            get { return (Class_user) Class_user.Get_obj(IdUser); }
            set { IdUser = value.Id; }
        }

        public Class_tvshow Tvshow
        {
            get { return Class_tvshow.Get_obj(IdTVShow); }
            set { IdTVShow = value.Id; }
        }

        public Class_favorites_and_user(Class_user user, Class_tvshow tvshow)
        {
            User = user;
            Tvshow = tvshow;
            Save(Dtable);
        }

        public Class_favorites_and_user(){}

        public static ObservableCollection<Class_favorites_and_user> Init_favorites_and_user()
        {
            var favoritesAndMan = new Class_favorites_and_user();
            Items = favoritesAndMan.Get(Dtable);
            return Items;
        }

        public static bool Equals(Class_user user, Class_tvshow tvshow)
        {
            return Items.Any(favorites_and_user => favorites_and_user.User == user && favorites_and_user.Tvshow == tvshow);
        }
    }
}
