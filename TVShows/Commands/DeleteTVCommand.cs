using TVShows.Data;

namespace TVShows
{
    #region Delete Command

    public class TVDeleteBehavior : CommandBehaviour<Class_tvshow>
    { }

    public class TVDeleteCommand : Command<Class_tvshow, TVDeleteBehavior>
    { }

    #endregion
}
