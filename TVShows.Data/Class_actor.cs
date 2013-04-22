using System;

namespace TVShows.Data
{
    public class Class_actor : Class_member_team
    {
        public static string Dtable = "Actors";
        
        public Class_actor(){}

        public Class_actor(string name_actor, DateTime birth_day, string birth_place, int age, string link_image)
        {
            Name = name_actor;
            Birth_day = birth_day;
            Birth_place = birth_place;
            Age = age;
            Link_image = link_image;
            Save(Dtable);
        }
    }
}
