using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVShows.Data;

namespace TVShows
{
    #region Edit Command

    public class TVEditBehavior : CommandBehaviour<Class_tvshow>
    {
        //public TVEditBehavior()
        //    : base((s, e) =>
        //    {
        //        var vm = (UserViewModel)(s as MenuItem).DataContext;
        //        var editView = new ManipulatorView(new ManipulatorViewModel(vm.SelectedUser, true)) { Owner = Application.Current.MainWindow };

        //        var control = UsersViewControl.Instance();
        //        control.grid.Model.CurrencyManager.ConfirmChanges();

        //        if ((bool)editView.ShowDialog())
        //        {
        //            return (editView.DataContext as ManipulatorViewModel).User;
        //        }
        //        return null;
        //    })
        //{ }
    }

    public class TVEditCommand : Command<Class_tvshow, TVEditBehavior>
    { }

    #endregion
}
