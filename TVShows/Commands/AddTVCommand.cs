using System.Windows;
using TVShows.Data;

namespace TVShows
{
    #region Add Command

    public class TVAddBehavior : CommandBehaviour<Class_tvshow>
    {
        public TVAddBehavior()
            : base((s, e) =>
            {
                var viewModel = new TVShowManipulatorViewModel(null, false);
                var addView = new TVShowView(viewModel)
                {
                    Owner = Application.Current.MainWindow,
                    TbId = { IsEnabled = false }
                };

                if ((bool)addView.ShowDialog())
                {
                    return viewModel.TV;
                }
                return null;
            })
        { }
    }

    public class TVAddCommand : Command<Class_tvshow, TVAddBehavior>
    { }

    #endregion
}
