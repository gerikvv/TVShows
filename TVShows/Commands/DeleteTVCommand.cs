using TVShows.Data.Classes;

namespace TVShows.Commands
{
    #region Delete Command

    public class TVDeleteBehavior : CommandBehaviour<Tvshow>
    { }

    public class TVDeleteCommand : Command<Tvshow, TVDeleteBehavior>
    { }

    #endregion
}
