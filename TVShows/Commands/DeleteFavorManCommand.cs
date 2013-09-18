using TVShows.Data;

namespace TVShows
{
    #region Delete Command

    public class FavorManDeleteBehavior : CommandBehaviour<Class_favorites_and_man>
    { }

    public class DeleteFavorManCommand : Command<Class_favorites_and_man, FavorManDeleteBehavior>
    { }

    #endregion
}
