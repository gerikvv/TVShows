using System.Windows;
using System.Windows.Controls;
using TVShows.Data.Classes;
using TVShows.UserControls;
using TVShows.View;
using TVShows.ViewModel;

namespace TVShows.Commands
{
    #region Edit Command

    public class UserEditBehavior : CommandBehaviour<User>
    {
        public UserEditBehavior()
            : base((s, e) =>
            {
                var vm = (UserViewModel)(s as MenuItem).DataContext;
                var editView = new UserView(new UserManipulatorViewModel(vm.SelectedUser, true))
                                               {Owner = Application.Current.MainWindow};

                var control = UsersViewControl.Instance();
                control.grid.Model.CurrencyManager.ConfirmChanges();

                if ((bool)editView.ShowDialog())
                {
                    return (editView.DataContext as UserManipulatorViewModel).User;
                }
                return null;
            })
        { }
    }

    public class UserEditCommand : Command<User, UserEditBehavior>
    { }

    #endregion
}
