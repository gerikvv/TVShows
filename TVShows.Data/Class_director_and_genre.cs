using System;

namespace TVShows.Data
{
    public class Class_director_and_genre : Class_base<Class_director_and_genre>
    {
        public static string Dtable = "Directors_and_Genres";

        public int IdDirector;
        public int IdGenre;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdDirector;
                objects[2] = IdGenre;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdDirector = (int)objects[1];
                IdGenre = (int)objects[2];
            }
        }

        public Class_director Director
        {
            get { return (Class_director)Class_director.Items[IdDirector]; }
            set { IdDirector = value.Id; }
        }

        public Class_genre Genre
        {
            get { return Class_genre.Items[IdGenre]; }
            set { IdGenre = value.Id; }
        }

        public Class_director_and_genre(Class_director director, Class_genre genre)
        {
            Director = director;
            Genre = genre;
            Save(Dtable);
        }
    }
}
