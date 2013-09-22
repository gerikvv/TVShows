using TVShows.Data;

namespace TVShows
{
    #region Delete Command

    public class FavorManDeleteBehavior : CommandBehaviour<Class_favorites_and_user>
    { }

    public class DeleteFavorManCommand : Command<Class_favorites_and_user, FavorManDeleteBehavior>
    { }

    #endregion
}
