using System;

namespace TVShows.Data.Classes
{
    public class Member_team : Base<Member_team>
    {
        public DateTime Birth_day { get; set; }
        public string Birth_place { get; set; }
        public int Age { get; set; }
        public string Link_image { get; set; }

        public override object[] Objparams
        {
            get
            {
                objects = new object[6];
                objects[0] = Id;
                objects[1] = Name;
                objects[2] = Birth_day;
                objects[3] = Birth_place;
                objects[4] = Age;
                objects[5] = Link_image;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                Name = (string)objects[1];
                Birth_day = (DateTime)objects[2];
                Birth_place = (string)objects[3];
                Age = (int)objects[4];
                Link_image = (string)objects[5];
            }
        }
    }
}
