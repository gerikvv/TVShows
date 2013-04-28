using System;

namespace TVShows.Data
{
    public class Class_ratedtvshow_and_user : Class_base<Class_ratedtvshow_and_user>
    {
        public static string Dtable = "RatedTVShows_and_Users";

        public int IdUser;
        public int IdTVShow;
        public int Rating;

        public override object[] Objparams
        {
            get
            {
                objects = new object[4];
                objects[0] = Id;
                objects[1] = IdUser;
                objects[2] = IdTVShow;
                objects[3] = Rating;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdUser = (int)objects[1];
                IdTVShow = (int)objects[2];
                Rating = (int) objects[3];
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

        public Class_ratedtvshow_and_user(Class_user user, Class_tvshow tvshow, int rating)
        {
            User = user;
            Tvshow = tvshow;
            Rating = rating;
            Save(Dtable);
        }
    }
}
