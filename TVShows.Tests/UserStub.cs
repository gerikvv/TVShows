using TVShows.Data.Classes;
using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    public class UserStub : IUser
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

        public Rating GetRating()
        {
            return new Rating(5);
        }

        public void Rate(ITvShow tvshow)
        {
            new User_and_Rating(this, tvshow, GetRating());
        }
    }
}
