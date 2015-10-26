namespace TVShows.Data.Interfaces
{
    public interface IAdministrator : IMan
    {
        void AddFavoriteTv(ITvShow tvshow);
    }
}
