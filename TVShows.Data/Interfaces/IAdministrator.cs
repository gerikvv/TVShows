namespace TVShows.Data.Interfaces
{
    public interface IAdministrator : IBase
    {
        void AddFavoriteTv(ITvShow tvshow);
    }
}
