using TVShows.Data.Classes;

namespace TVShows.Data.Interfaces
{
    public interface IUser : IMan
    {
        void AddFavoriteTv(ITvShow tvshow);
        Rating GetRating();
        void Rate(ITvShow tvshow);
    }
}
