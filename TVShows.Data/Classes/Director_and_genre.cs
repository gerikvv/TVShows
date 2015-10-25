using System;

namespace TVShows.Data.Classes
{
    public class Director_and_genre : Base<Director_and_genre>
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

        public Director Director
        {
            get { return (Director)Director.Items[IdDirector]; }
            set { IdDirector = value.Id; }
        }

        public Genre Genre
        {
            get { return Genre.Items[IdGenre]; }
            set { IdGenre = value.Id; }
        }

        public Director_and_genre(){}

        public Director_and_genre(Director director, Genre genre)
        {
            Director = director;
            Genre = genre;
            Save();
        }
    }
}
