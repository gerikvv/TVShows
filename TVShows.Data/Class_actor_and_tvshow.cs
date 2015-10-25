using System;

namespace TVShows.Data
{
    public class Class_actor_and_tvshow : Class_base<Class_actor_and_tvshow>
    {
        public static string Dtable = "Actors_and_TVShows";

        public int IdActor;
        public int IdTVShow;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdActor;
                objects[2] = IdTVShow;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdActor = (int)objects[1];
                IdTVShow = (int)objects[2];
            }
        }

        public Class_actor Actor
        {
            get { return (Class_actor) Class_actor.Items[IdActor]; }
            set { IdActor = value.Id; }
        }

        public Class_tvshow Tvshow
        {
            get { return Class_tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Class_actor_and_tvshow(){}

        public Class_actor_and_tvshow(Class_actor actor, Class_tvshow tvshow)
        {
            Actor = actor;
            Tvshow = tvshow;
            Save();
        }
    }
}
