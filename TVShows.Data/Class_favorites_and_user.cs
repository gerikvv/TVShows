using System;
using System.Collections.ObjectModel;
using System.Linq;
using TVShows.Data.Interfaces;

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

        public IUser User
        {
            get { return Class_user.Get_obj(IdUser); }
            set { IdUser = value.Id; }
        }

        public ITvShow Tvshow
        {
            get { return Class_tvshow.Get_obj(IdTVShow); }
            set { IdTVShow = value.Id; }
        }

        public Class_favorites_and_user(){}

        public Class_favorites_and_user(IUser user, ITvShow tvshow)
        {
            User = user;
            Tvshow = tvshow;
            Save();
        }

        public static ObservableCollection<Class_favorites_and_user> Init_favorites_and_user()
        {
            Items = Repository.GetAllObjects();
            return Items;
        }

        public static bool Equals(IUser user, ITvShow tvshow)
        {
            return Items.Any(favoritesAndUser => favoritesAndUser.User == user && favoritesAndUser.Tvshow == tvshow);
        }
    }
}
