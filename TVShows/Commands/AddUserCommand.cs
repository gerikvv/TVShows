using System.Windows;
using TVShows.Data.Classes;
using TVShows.View;
using TVShows.ViewModel;

namespace TVShows.Commands
{
    #region Add Command

    public class UserAddBehavior : CommandBehaviour<User>
    {
        public UserAddBehavior()
            : base((s, e) =>
            {
                var viewModel = new UserManipulatorViewModel(null, false);
                var addView = new UserView(viewModel)
                                  {
                                      Owner = Application.Current.MainWindow,
                                      TbId = {IsEnabled = false}
                                  };

                if ((bool)addView.ShowDialog())
                {
                    return viewModel.User;
                }
                return null;
            })
        { }
    }

    public class UserAddCommand : Command<User, UserAddBehavior>
    { }

    #endregion
}