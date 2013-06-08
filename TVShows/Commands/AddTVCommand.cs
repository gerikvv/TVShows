using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVShows.Data;

namespace TVShows
{
    #region Add Command

    public class TVAddBehavior : CommandBehaviour<Class_tvshow>
    {
        //public UserAddBehavior()
        //    : base((s, e) =>
        //    {
        //        var viewModel = new ManipulatorViewModel(null, false);
        //        var addView = new ManipulatorView(viewModel)
        //        {
        //            Owner = Application.Current.MainWindow,
        //            TbId = { IsEnabled = false }
        //        };

        //        if ((bool)addView.ShowDialog())
        //        {
        //            return viewModel.User;
        //        }
        //        return null;
        //    })
        //{ }
    }

    public class TVAddCommand : Command<Class_tvshow, TVAddBehavior>
    { }

    #endregion
}
