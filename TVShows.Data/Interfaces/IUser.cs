namespace TVShows.Data.Interfaces
{
    public interface IUser : IMan
    {
        void AddFavoriteTv(ITvShow tvshow);
    }
}
