using System.Windows;
using TVShows.Data;

namespace TVShows
{
    #region Add Command

    public class UserAddBehavior : UserCommandBehaviour<Class_user>
    {
        public UserAddBehavior()
            : base((s, e) =>
            {
                //ManipulatorViewModel viewModel = new ManipulatorViewModel(null, false);
                //ManipulatorView addView = new ManipulatorView(viewModel);
                //addView.Owner = Application.Current.MainWindow;

                //if ((bool)addView.ShowDialog())
                //{
                //    return viewModel.EmployeeInfo;
                //}
                return null;
            })
        { }
    }

    public class UserAddCommand : UserCommand<Class_user, UserAddBehavior>
    { }

    #endregion
}