using System.Windows;
using TVShows.Data.Classes;
using TVShows.View;
using TVShows.ViewModel;

namespace TVShows.Commands
{
    #region Add Command

    public class TVAddBehavior : CommandBehaviour<Tvshow>
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

    public class TVAddCommand : Command<Tvshow, TVAddBehavior>
    { }

    #endregion
}
