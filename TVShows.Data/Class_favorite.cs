using System;

namespace TVShows.Data
{
    public class Class_favorite : Class_base<Class_favorite>
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

        public Class_user User
        {
            get { return (Class_user) Class_user.Items[IdUser]; }
            set { IdUser = value.Id; }
        }

        public Class_tvshow Tvshow
        {
            get { return Class_tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Class_favorite(){}

        public Class_favorite(Class_user user, Class_tvshow tvshow)
        {
            User = user;
            Tvshow = tvshow;
            Save();
        }
    }
}
