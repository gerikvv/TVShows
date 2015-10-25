using System;

namespace TVShows.Data.Classes
{
    public class Actor_and_genre : Base<Actor_and_genre>
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

        public Actor Actor
        {
            get { return (Actor) Actor.Items[IdActor]; }
            set { IdActor = value.Id; }
        }

        public Genre Genre
        {
            get { return Genre.Items[IdGenre]; }
            set { IdGenre = value.Id; }
        }

        public Actor_and_genre(){}

        public Actor_and_genre(Actor actor, Genre genre)
        {
            Actor = actor;
            Genre = genre;
            Save();
        }
    }
}
