using System.Collections.Generic;
using TVShows.Data.Classes;
using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    public class UserSpy : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object[] Objparams { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<Call<IUser>> Calls = new List<Call<IUser>>();

        public void Save()
        {
            Calls.Add(new Call<IUser>("Save", this));
        }

        public void Delete()
        {
            Calls.Add(new Call<IUser>("Delete", this));
        }

        public void Update()
        {
            Calls.Add(new Call<IUser>("Update", this));
        }

        public void AddFavoriteTv(ITvShow tvshow)
        {
            Calls.Add(new Call<IUser>("AddFavoriteTv", this));
            new Favorites_and_user(this, tvshow);
        }

        public Rating GetRatingFromWindow()
        {
            Calls.Add(new Call<IUser>("GetRating", this));
            return new Rating(5);
        }

        public void Rate(ITvShow tvshow)
        {
            Calls.Add(new Call<IUser>("Rate", this));
            new User_and_Rating(this, tvshow, GetRatingFromWindow());
        }
    }
}
