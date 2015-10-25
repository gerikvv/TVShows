using TVShows.Data.Classes;

namespace TVShows.Commands
{
    #region Delete Command

    public class UserDeleteBehavior : CommandBehaviour<User>
    { }

    public class UserDeleteCommand : Command<User, UserDeleteBehavior>
    { }

    #endregion
}
