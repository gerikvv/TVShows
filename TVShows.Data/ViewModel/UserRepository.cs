using System.Collections.ObjectModel;

namespace TVShows.Data.ViewModel
{
    public class UserRepository
    {
        #region Properties
        ObservableCollection<Class_user> users = new ObservableCollection<Class_user>();

        public ObservableCollection<Class_user> Users
        {
            get { return users; }
            set { users = value; }
        }
        #endregion

        #region Constructor
        public UserRepository()
        {
            Users = new ObservableCollection<Class_user>();
            this.Add_users();
        }
        #endregion

        #region Methods
        public void Add_users ()
        {
            foreach (var user in Class_user.Items)
            {
                if (user.GetType() == typeof(Class_user))
                    users.Add((Class_user) user);
            }
        }
        #endregion

    }
}
