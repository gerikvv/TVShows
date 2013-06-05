using System.Data;
using System.Windows;
using Syncfusion.Windows.Shared;
using TVShows.Data;

namespace TVShows
{
    public class UserViewModel : UserRepository
    {
        #region Properties

        private readonly DelegateCommand<Class_user> add_user;
        private readonly DelegateCommand<Class_user> edit_user;
        private readonly DelegateCommand<Class_user> delete_user;
        private Class_user selected_user;

        public Class_user SelectedUser
        {
            get { return selected_user; }
            set { selected_user = value; }
        }

        public DelegateCommand<Class_user> AddUser
        {
            get { return add_user; }
        }

        public DelegateCommand<Class_user> EditUser
        {
            get { return edit_user; }
        }

        public DelegateCommand<Class_user> DeleteUser
        {
            get { return delete_user; }
        }

        #endregion

        #region Constructor

        public UserViewModel()
        {
            add_user = new DelegateCommand<Class_user>(AddUserHandler, Can_Add_User);
            edit_user = new DelegateCommand<Class_user>(UpdateZipCodeHandler, Can_update_user);
            delete_user = new DelegateCommand<Class_user>(DeleteUserHandler, Can_delete_user);
        }

        #endregion

        #region Command Handler

        bool Can_Add_User(Class_user user)
        {
            return true;
        }

        public void AddUserHandler(Class_user user)
        {
            this.Users.Add(user);
        }

        bool Can_update_user(Class_user user)
        {
            return this.SelectedUser != null;
        }

        bool Can_delete_user(Class_user user)
        {
            return this.SelectedUser != null;
        }

        public void UpdateZipCodeHandler(Class_user user)
        {
            if (user == null)
                return;

            selected_user.Id = user.Id;
            selected_user.Name = user.Name;
            selected_user.Password = user.Password;
            selected_user.Email = user.Email;
        }

        public void DeleteUserHandler(Class_user user)
        {
            if (user == null)
                return;

            user.Delete(Class_user.Dtable, user.Id);
            this.Users.Remove(user);
        }

        #endregion
    }
}

