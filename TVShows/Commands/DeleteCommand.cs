using TVShows.Data;

namespace TVShows
{
    #region Delete Command

    public class UserDeleteBehavior : UserCommandBehaviour<Class_user>
    { }

    public class UserDeleteCommand : UserCommand<Class_user, UserDeleteBehavior>
    { }

    #endregion
}
