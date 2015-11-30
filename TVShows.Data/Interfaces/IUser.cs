using TVShows.Data.Classes;

namespace TVShows.Data.Interfaces
{
    public interface IUser : IMan
    {
        void AddFavoriteTv(ITvShow tvshow);
        Rating GetRatingFromWindow();
        void Rate(ITvShow tvshow);
    }
}
