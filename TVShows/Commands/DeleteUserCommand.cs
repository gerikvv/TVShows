using TVShows.Data;

namespace TVShows
{
    #region Delete Command

    public class UserDeleteBehavior : CommandBehaviour<Class_user>
    { }

    public class UserDeleteCommand : Command<Class_user, UserDeleteBehavior>
    { }

    #endregion
}
