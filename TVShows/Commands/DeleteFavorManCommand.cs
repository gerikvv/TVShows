using TVShows.Data.Classes;

namespace TVShows.Commands
{
    #region Delete Command

    public class FavorManDeleteBehavior : CommandBehaviour<Favorites_and_user>
    { }

    public class DeleteFavorManCommand : Command<Favorites_and_user, FavorManDeleteBehavior>
    { }

    #endregion
}
