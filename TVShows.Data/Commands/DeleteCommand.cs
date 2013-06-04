using System.Data;

namespace TVShows.Data
{
    #region Delete Command

    public class UserDeleteBehavior : UserCommandBehaviour<DataRow>
    { }

    public class UserDeleteCommand : UserCommand<DataRow, UserDeleteBehavior>
    { }

    #endregion
}
