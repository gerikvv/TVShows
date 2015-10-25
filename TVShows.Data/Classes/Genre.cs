using System;

namespace TVShows.Data.Classes
{
    public class Genre : Base<Genre>
    {
        public static string Dtable = "Genres";

        public override object[] Objparams
        {
            get
            {
                objects = new object[2];
                objects[0] = Id;
                objects[1] = Name;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                Name = (string)objects[1];
            }
        }
        public Genre(){}

        public Genre(string name)
        {
            Name = name;
            Save();
        }
    }
}
