using System.Windows;
using TVShows.Data;

namespace TVShows
{
    #region Add Command

    public class UserAddBehavior : CommandBehaviour<Class_user>
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

    public class UserAddCommand : Command<Class_user, UserAddBehavior>
    { }

    #endregion
}