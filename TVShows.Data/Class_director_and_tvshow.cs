using System;

namespace TVShows.Data
{
    public class Class_director_and_tvshow : Class_base<Class_director_and_tvshow>
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

        public Class_director Director
        {
            get { return (Class_director) Class_director.Items[IdDirector]; }
            set { IdDirector = value.Id; }
        }

        public Class_tvshow Tvshow
        {
            get { return Class_tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Class_director_and_tvshow(Class_director director, Class_tvshow tvshow)
        {
            Director = director;
            Tvshow = tvshow;
            Save(Dtable);
        }
    }
}
