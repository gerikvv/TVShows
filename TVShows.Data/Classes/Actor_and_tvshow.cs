using System;

namespace TVShows.Data.Classes
{
    public class Actor_and_tvshow : Base<Actor_and_tvshow>
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

        public Actor Actor
        {
            get { return (Actor) Actor.Items[IdActor]; }
            set { IdActor = value.Id; }
        }

        public Tvshow Tvshow
        {
            get { return Tvshow.Items[IdTVShow]; }
            set { IdTVShow = value.Id; }
        }

        public Actor_and_tvshow(){}

        public Actor_and_tvshow(Actor actor, Tvshow tvshow)
        {
            Actor = actor;
            Tvshow = tvshow;
            Save();
        }
    }
}
