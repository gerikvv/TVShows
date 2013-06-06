using System.Data;
using System.Windows;
using Syncfusion.Windows.Shared;
using TVShows.Data;

namespace TVShows
{
    //public class UserViewModel : UserRepository
    //{
    //    #region Properties

    //    private readonly DelegateCommand<Class_user> add_user;
    //    private readonly DelegateCommand<Class_user> edit_user;
    //    private readonly DelegateCommand<Class_user> delete_user;
    //    private Class_user selected_user;

    //    public Class_user SelectedUser
    //    {
    //        get { return selected_user; }
    //        set { selected_user = value; }
    //    }

    //    public DelegateCommand<Class_user> AddUser
    //    {
    //        get { return add_user; }
    //    }

    //    public DelegateCommand<Class_user> EditUser
    //    {
    //        get { return edit_user; }
    //    }

    //    public DelegateCommand<Class_user> DeleteUser
    //    {
    //        get { return delete_user; }
    //    }

    //    #endregion

    //    #region Constructor

    //    public UserViewModel()
    //    {
    //        add_user = new DelegateCommand<Class_user>(AddUserHandler, Can_Add_User);
    //        edit_user = new DelegateCommand<Class_user>(UpdateZipCodeHandler, Can_update_user);
    //        delete_user = new DelegateCommand<Class_user>(DeleteUserHandler, Can_delete_user);
    //    }

    //    #endregion

    //    #region Command Handler

    //    bool Can_Add_User(Class_user user)
    //    {
    //        return true;
    //    }

    //    public void AddUserHandler(Class_user user)
    //    {
    //        this.Users.Add(user);
    //    }

    //    bool Can_update_user(Class_user user)
    //    {
    //        return this.SelectedUser != null;
    //    }

    //    bool Can_delete_user(Class_user user)
    //    {
    //        return this.SelectedUser != null;
    //    }

    //    public void UpdateZipCodeHandler(Class_user user)
    //    {
    //        if (user == null)
    //            return;

    //        selected_user.Id = user.Id;
    //        selected_user.Name = user.Name;
    //        selected_user.Password = user.Password;
    //        selected_user.Email = user.Email;
    //    }

    //    public void DeleteUserHandler(Class_user user)
    //    {
    //        if (user == null)
    //            return;

    //        user.Delete(Class_user.Dtable, user.Id);
    //        this.Users.Remove(user);
    //    }

    //    #endregion
    //}

    public class UserViewModel : NotificationObject
    {
        #region Constructor

        public UserViewModel()
        {

            this.UsersDtable = this.Get_class_users();
            _addUser = new DelegateCommand<Class_user>(AddUserHandler, CanAddUser);
            _editUser = new DelegateCommand<Class_user>(UpdateUserHandler, CanUpdateUser);
            _deleteUser = new DelegateCommand<DataRowView>(DeleteUserHandler);
        }
        #endregion

        #region Command Handler

        bool CanAddUser(Class_user user)
        {
            return true;
        }

        public void AddUserHandler(Class_user user)
        {
            if (user == null)
            {
                return;
            }
            var row = UsersDtable.NewRow();
            row["Id"] = user.Id;
            row["Name"] = user.Name;
            row["Password"] = user.Password;
            row["Email"] = user.Email;
            UsersDtable.Rows.Add(row);

            Class_user.Items.Add(user);
            user.Save(Class_user.Dtable);
        }

        bool CanUpdateUser(Class_user user)
        {
            return this.SelectedUser != null;
        }

        public void UpdateUserHandler(Class_user user)
        {
            if (user == null)
                return;
            ((DataRowView)selected_user)["Id"] = user.Id;
            ((DataRowView)selected_user)["Name"] = user.Name;
            ((DataRowView)selected_user)["Password"] = user.Password;
            ((DataRowView)selected_user)["Email"] = user.Email;
        }

        public void DeleteUserHandler(DataRowView user)
        {
            if (user == null)
                return;

            foreach (var classUser in Class_user.Items)
                if (classUser.Id == (int) user.Row["Id"])
                    classUser.Delete(Class_user.Dtable, classUser.Id);

            this.UsersDtable.Rows.Remove(user.Row);
        }

        #endregion

        private readonly DelegateCommand<Class_user> _addUser;
        private readonly DelegateCommand<Class_user> _editUser;
        private readonly DelegateCommand<DataRowView> _deleteUser;

        public DelegateCommand<Class_user> AddUser
        {
            get { return _addUser; }
        }

        public DelegateCommand<Class_user> EditUser
        {
            get { return _editUser; }
        }

        public DelegateCommand<DataRowView> DeleteUser
        {
            get { return _deleteUser; }
        }

        #region Properties

        private DataTable usersDtable;

        public DataTable UsersDtable
        {
            get { return usersDtable; }
            set { usersDtable = value; }
        }

        private DataRowView selected_user;

        public DataRowView SelectedUser
        {
            get { return selected_user; }
            set
            {
                selected_user = value;
                RaisePropertyChanged("SelectedUser");
            }
        }

        #endregion

        #region Methods

        public DataTable Get_class_users()
        {
            var ds = new DataTable();
            ds.Columns.Add("Id", typeof(int));
            ds.Columns.Add("Name", typeof(string));
            ds.Columns.Add("Password", typeof(string));
            ds.Columns.Add("Email", typeof(string));

            foreach (var user in Class_user.Items)
            {
                if (user.GetType() == typeof(Class_user))
                    ds.Rows.Add(user.Id, user.Name, user.Password, user.Email);
            }
            return ds;
        }
        #endregion
    }   
}

