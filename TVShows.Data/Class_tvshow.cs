using System;

namespace TVShows.Data
{
    public class Class_tvshow : Class_base<Class_tvshow>
    {
        public static string Dtable = "TVShows";

        public int Year { get; set; }
        public string Country { get; set; }
        public string Slogan { get; set; }
        public string Script_writer { get; set; }
        public string Producer { get; set; }
        public int Budget { get; set; }
        public int Global_charges { get; set; }
        public DateTime Time { get; set; }
        public int Overall_rating { get; set; }
        public string Link_image { get; set; }

        public override object[] Objparams
        {
            get
            {
                objects = new object[12];
                objects[0] = Id;
                objects[1] = Name;
                objects[2] = Year;
                objects[3] = Country;
                objects[4] = Slogan;
                objects[5] = Script_writer;
                objects[6] = Producer;
                objects[7] = Budget;
                objects[8] = Global_charges;
                objects[9] = Time;
                objects[10] = Overall_rating;
                objects[11] = Link_image;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                Name = (string)objects[1];
                Year = (int)objects[2];
                Country = (string)objects[3];
                Slogan = (string)objects[4];
                Script_writer = (string)objects[5];
                Producer = (string)objects[6];
                Budget = (int)objects[7];
                Global_charges = (int)objects[8];
                Time = (DateTime)objects[9];
                Overall_rating = (int)objects[10];
                Link_image = (string)objects[11];
            }
        }
        public Class_tvshow(){}

        public Class_tvshow(string name, int year, string country, string slogan, string script_writer, 
        string producer, int budget, int global_charges, DateTime time, int overall_rating, string link_image)
        {
            Name = name;
            Year = year;
            Country = country;
            Slogan = slogan;
            Script_writer = script_writer;
            Producer = producer;
            Budget = budget;
            Global_charges = global_charges;
            Time = time;
            Overall_rating = overall_rating;
            Link_image = link_image;
            Save(Dtable);
        }
    }
}
