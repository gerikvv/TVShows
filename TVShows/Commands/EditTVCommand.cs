using System.Windows;
using System.Windows.Controls;
using TVShows.Data.Classes;
using TVShows.UserControls;
using TVShows.View;
using TVShows.ViewModel;

namespace TVShows.Commands
{
    #region Edit Command

    public class TVEditBehavior : CommandBehaviour<Tvshow>
    {
        public TVEditBehavior()
            : base((s, e) =>
            {
                var vm = (TVShowViewModel)(s as MenuItem).DataContext;
                var editView = new TVShowView(new TVShowManipulatorViewModel(vm.SelectedTV, true)) 
                { Owner = Application.Current.MainWindow };

                var control = TVShowsViewControl.Instance();
                control.grid.Model.CurrencyManager.ConfirmChanges();

                if ((bool)editView.ShowDialog())
                {
                    return (editView.DataContext as TVShowManipulatorViewModel).TV;
                }
                return null;
            })
        { }
    }

    public class TVEditCommand : Command<Tvshow, TVEditBehavior>
    { }

    #endregion
}
