using System;

namespace TVShows.Data.Classes
{
    public class Director_and_tvshow : Base<Director_and_tvshow>
    {
        public static string Dtable = "Directors_and_TVShows";

        public int IdDirector;
        public int IdTVShow;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdDirector;
                objects[2] = IdTVShow;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdDirector = (int)objects[1];
                IdTVShow = (int)objects[2];
            }
        }

        public Director Director
        {
            get { return (Director) Director.Items[IdDirector]; }
            set { IdDirector = value.Id; }
        }

        public Tvshow Tvshow
        {
            get { return Tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Director_and_tvshow(){}

        public Director_and_tvshow(Director director, Tvshow tvshow)
        {
            Director = director;
            Tvshow = tvshow;
            Save();
        }
    }
}
