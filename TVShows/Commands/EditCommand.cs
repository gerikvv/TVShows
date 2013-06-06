using System.Windows;
using System.Windows.Controls;
using TVShows.Data;

namespace TVShows
{
    #region Edit Command

    public class UserEditBehavior : UserCommandBehaviour<Class_user>
    {
        public UserEditBehavior()
            : base((s, e) =>
            {
                var vm = (UserViewModel)(s as MenuItem).DataContext;
                var editView = new ManipulatorView(new ManipulatorViewModel(vm.SelectedUser, true))
                                               {Owner = Application.Current.MainWindow};

                if ((bool)editView.ShowDialog())
                {
                    return (editView.DataContext as ManipulatorViewModel).User;
                }
                return null;
            })
        { }
    }

    public class UserEditCommand : UserCommand<Class_user, UserEditBehavior>
    { }

    #endregion
}
