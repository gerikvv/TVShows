using System;

namespace TVShows.Data
{
    public class Class_genre : Class_base<Class_genre>
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
        public Class_genre(){}

        public Class_genre(string name)
        {
            Name = name;
            Save(Dtable);
        }
    }
}
