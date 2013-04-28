using System;

namespace TVShows.Data
{
    public class Class_actor_and_genre : Class_base<Class_actor_and_genre>
    {
        public static string Dtable = "Actors_and_Genres";

        public int IdActor;
        public int IdGenre;

        public override object[] Objparams
        {
            get
            {
                objects = new object[3];
                objects[0] = Id;
                objects[1] = IdActor;
                objects[2] = IdGenre;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                IdActor = (int)objects[1];
                IdGenre = (int)objects[2];
            }
        }

        public Class_actor Actor
        {
            get { return (Class_actor) Class_actor.Items[IdActor]; }
            set { IdActor = value.Id; }
        }

        public Class_genre Genre
        {
            get { return Class_genre.Items[IdGenre]; }
            set { IdGenre = value.Id; }
        }

        public Class_actor_and_genre(Class_actor actor, Class_genre genre)
        {
            Actor = actor;
            Genre = genre;
            Save(Dtable);
        }
    }
}
