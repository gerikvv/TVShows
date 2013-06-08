using System.Windows;
using System.Windows.Controls;
using TVShows.Data;

namespace TVShows
{
    #region Edit Command

    public class UserEditBehavior : CommandBehaviour<Class_user>
    {
        public UserEditBehavior()
            : base((s, e) =>
            {
                var vm = (UserViewModel)(s as MenuItem).DataContext;
                var editView = new UserView(new ManipulatorViewModel(vm.SelectedUser, true))
                                               {Owner = Application.Current.MainWindow};

                var control = UsersViewControl.Instance();
                control.grid.Model.CurrencyManager.ConfirmChanges();

                if ((bool)editView.ShowDialog())
                {
                    return (editView.DataContext as ManipulatorViewModel).User;
                }
                return null;
            })
        { }
    }

    public class UserEditCommand : Command<Class_user, UserEditBehavior>
    { }

    #endregion
}
