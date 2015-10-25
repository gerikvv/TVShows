using System;

namespace TVShows.Data.Classes
{
    public class Director : Member_team
    {
        public static string Dtable = "Directors";
        
        public Director(){}

        public Director(string name_director, DateTime birth_day, string birth_place, int age, string link_image)
        {
            Name = name_director;
            Birth_day = birth_day;
            Birth_place = birth_place;
            Age = age;
            Link_image = link_image;
            Save();
        }
    }
}
