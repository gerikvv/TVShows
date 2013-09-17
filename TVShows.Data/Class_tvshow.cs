using System;
using System.Data;

namespace TVShows.Data
{
    public class Class_tvshow : Class_base<Class_tvshow>
    {
        public static string Dtable = "TVShows";

        private int year;
        public int Year 
        {
            get { return year; }
            set
            {
                year = value;
                RaisePropertyChanged("Year");
            } 
        }

        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                RaisePropertyChanged("Country");
            }
        }

        private string slogan;
        public string Slogan
        {
            get { return slogan; } 
            set
            {
                slogan = value;
                RaisePropertyChanged("Slogan");
            }
        }

        private string script_writer;
        public string Script_writer
        {
            get { return script_writer; }
            set
            {
                script_writer = value;
                RaisePropertyChanged("Script_writer");
            }
        }

        private string producer;
        public string Producer
        {
            get { return producer; }
            set
            {
                producer = value;
                RaisePropertyChanged("Producer");
            }
        }

        private int budget;
        public int Budget
        {
            get { return budget; }
            set
            {
                budget = value;
                RaisePropertyChanged("Budget");
            }
        }

        public string Budget_string { get; set; }

        private int global_charges;
        public int Global_charges
        {
            get { return global_charges; }
            set
            {
                global_charges = value;
                RaisePropertyChanged("Global_charges");
            }
        }

        public string Global_charges_string { get; set; }

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set
            {
                time = value;
                RaisePropertyChanged("Time");
            }
        }

        public string Time_string { get; set; }

        private double overall_rating;
        public double Overall_rating
        {
            get { return overall_rating; }
            set
            {
                overall_rating = value;
                RaisePropertyChanged("Overall_rating");
            }
        }

        private string name_image;
        public string Name_image
        {
            get { return name_image; }
            set
            {
                name_image = value;
                RaisePropertyChanged("Name_image");
            }
        }

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
                Year = (int)objects[2];
                Country = (string)objects[3];
                Slogan = (string)objects[4];
                Script_writer = (string)objects[5];
                Producer = (string)objects[6];
                Budget = (int)objects[7];
                Global_charges = (int)objects[8];
                Time = (DateTime)objects[9];
                Overall_rating = double.Parse(objects[10].ToString());
                Name_image = (string)objects[11];

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
        string producer, int budget, int global_charges, DateTime time, double overall_rating, string link_image)
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

        protected override void RaisePropertyChanged(string property_name)
        {
            base.RaisePropertyChanged(property_name);
            if (State == ConnectionState.Closed && Name != null && Year != 0 && Country != null && Slogan != null
                && Script_writer != null && Global_charges != 0 && Time != new DateTime(1,1,1,0,0,0) 
                && Overall_rating != 0 && Name_image != null)
                Update(Dtable);
        }
    }
}
