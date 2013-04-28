using System;

namespace TVShows.Data
{
    public class Class_tvshow_and_genre : Class_base<Class_tvshow_and_genre>
    {
        public static string Dtable = "TVShows_and_Genres";

        public int IdTVShow;
        public int IdGenre;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdTVShow;
                objects[2] = IdGenre;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdTVShow = (int)objects[1];
                IdGenre = (int)objects[2];
            }
        }

        public Class_tvshow Tvshow
        {
            get { return Class_tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Class_genre Genre
        {
            get { return Class_genre.Items[IdGenre]; }
            set { IdGenre = value.Id; }
        }

        public Class_tvshow_and_genre(Class_tvshow tvshow, Class_genre genre)
        {
            Tvshow = tvshow;
            Genre = genre;
            Save(Dtable);
        }
    }
}
