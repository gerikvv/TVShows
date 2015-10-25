using System;

namespace TVShows.Data.Classes
{
    public class Tvshow_and_genre : Base<Tvshow_and_genre>
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

        public Tvshow Tvshow
        {
            get { return Tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Genre Genre
        {
            get { return Genre.Items[IdGenre]; }
            set { IdGenre = value.Id; }
        }

        public Tvshow_and_genre(){}

        public Tvshow_and_genre(Tvshow tvshow, Genre genre)
        {
            Tvshow = tvshow;
            Genre = genre;
            Save();
        }
    }
}
