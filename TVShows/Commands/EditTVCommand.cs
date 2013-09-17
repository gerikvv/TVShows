using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TVShows.Data;

namespace TVShows
{
    #region Edit Command

    public class TVEditBehavior : CommandBehaviour<Class_tvshow>
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

    public class TVEditCommand : Command<Class_tvshow, TVEditBehavior>
    { }

    #endregion
}
