using System;
using TVShows.Data.Classes;
using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    public class Dummy : IUser, IAdministrator, ITvShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object[] Objparams { get; set; }

        public void Save(){}
        public void Delete(){}
        public void Update(){}

        public string Password { get; set; }
        public string Email { get; set; }

        public void AddFavoriteTv(ITvShow tvshow){}
        public Rating Rate()
        {
            return null;
        }

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
        public double Rating { get; set; }
    }
}
