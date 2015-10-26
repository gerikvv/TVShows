using System;
using System.Collections.Generic;
using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    public class TvSpy : ITvShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object[] Objparams { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public string Slogan { get; set; }
        public string Script_writer { get; set; }
        public string Producer { get; set; }
        public int Budget { get; set; }
        public int Global_charges { get; set; }
        public DateTime Time { get; set; }
        public double Overall_rating { get; set; }
        public string Name_image { get; set; }
        public string Link_image { get; set; }
        public string Director { get; set; }

        private double _rating;
        public double Rating
        {
            get { return _rating; }
            set
            {
                Calls.Add(new Call<ITvShow>("Rating", this));
                _rating = value;
            }
        }

        public List<Call<ITvShow>> Calls = new List<Call<ITvShow>>();

        public void Save()
        {
            Calls.Add(new Call<ITvShow>("Save", this));
        }

        public void Delete()
        {
            Calls.Add(new Call<ITvShow>("Delete", this));
        }

        public void Update()
        {
            Calls.Add(new Call<ITvShow>("Update", this));
        }
    }
}
