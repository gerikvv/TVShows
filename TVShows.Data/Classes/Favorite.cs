using System;

namespace TVShows.Data.Classes
{
    public class Favorite : Base<Favorite>
    {
        public static string Dtable = "Favorites";

        public int IdUser;
        public int IdTVShow;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdUser;
                objects[2] = IdTVShow;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdUser = (int)objects[1];
                IdTVShow = (int)objects[2];
            }
        }

        public User User
        {
            get { return (User) User.Items[IdUser]; }
            set { IdUser = value.Id; }
        }

        public Tvshow Tvshow
        {
            get { return Tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Favorite(){}

        public Favorite(User user, Tvshow tvshow)
        {
            User = user;
            Tvshow = tvshow;
            Save();
        }
    }
}
