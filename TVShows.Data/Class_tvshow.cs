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
        public string Budget_string { get; set; }
        public int Global_charges { get; set; }
        public string Global_charges_string { get; set; }
        public DateTime Time { get; set; }
        public String Time_string { get; set; }
        public string Overall_rating { get; set; }
        public string Name_image { get; set; }
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
                objects[11] = Name_image;
                return objects;
            }
            set
            {
                objects = value;
                Id = (Int32)objects[0];
                Name = (string)objects[1];
                On_property_changed("Name");
                Year = (int)objects[2];
                On_property_changed("Year");
                Country = (string)objects[3];
                On_property_changed("Country");
                Slogan = (string)objects[4];
                On_property_changed("Slogan");
                Script_writer = (string)objects[5];
                On_property_changed("Script_writer");
                Producer = (string)objects[6];
                On_property_changed("Producer");
                Budget = (int)objects[7];
                Global_charges = (int)objects[8];
                Time = (DateTime)objects[9];
                Overall_rating = (string)objects[10];
                On_property_changed("Overall_rating");
                Name_image = (string)objects[11];
                On_property_changed("Name_image");

                Budget_string = Budget.ToString("$### ### ### ###");
                On_property_changed("Budget_string");
                Global_charges_string = Global_charges.ToString("$### ### ### ###");
                On_property_changed("Global_charges_string");
                Time_string = (Time.Hour*60 + Time.Minute) + " мин. / " + Time.ToShortTimeString();
                On_property_changed("Time_string");
            }
        }
        public Class_tvshow(){}

        public Class_tvshow(string name, int year, string country, string slogan, string script_writer,
        string producer, int budget, int global_charges, DateTime time, string overall_rating, string link_image)
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
            On_property_changed("Link_image");
            Budget_string = budget.ToString("$### ### ### ###");
            Global_charges_string = global_charges.ToString("$### ### ### ###");
            Time_string = (Time.Hour * 60 + Time.Minute) + " мин. / " + Time.ToShortTimeString();
            Save(Dtable);
        }

        public static Class_tvshow Init_tv_show ()
        {
            var tvshow = new Class_tvshow();
            Items = tvshow.Get(Dtable);

            foreach (var tv in Items)
                tv.Link_image = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + tv.Name_image;

            var rand = new Random();
            var i = rand.Next(0, Items.Count);
            return Items[i];
        }
    }
}
