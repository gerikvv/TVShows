using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using TVShows.Data;

namespace TVShows
{
    #region Add Command

    public class UserAddBehavior : UserCommandBehaviour<Class_user>
    {
        public UserAddBehavior()
            : base((s, e) =>
            {
                var viewModel = new ManipulatorViewModel(null, false);
                var addView = new ManipulatorView(viewModel) {Owner = Application.Current.MainWindow};
                
                if ((bool)addView.ShowDialog())
                {
                    return viewModel.User;
                }
                return null;
            })
        { }
    }

    public class UserAddCommand : UserCommand<Class_user, UserAddBehavior>
    { }

    #endregion
}