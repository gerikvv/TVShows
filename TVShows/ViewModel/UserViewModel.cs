﻿using System.Data;
using Syncfusion.Windows.Shared;
using TVShows.Data.Classes;

namespace TVShows.ViewModel
{
    public class UserViewModel : NotificationObject
    {
        #region Constructor

        public UserViewModel()
        {
            UsersDtable = Get_users();
            _addUser = new DelegateCommand<User>(AddUserHandler);
            _editUser = new DelegateCommand<User>(UpdateUserHandler);
            _deleteUser = new DelegateCommand<DataRowView>(DeleteUserHandler);
        }
        #endregion

        #region Command Handler
        
        public void AddUserHandler(User user)
        {
            if (user == null)
                return;

            User.Items.Add(user);
            user.Save();

            var row = UsersDtable.NewRow();
            row["Id"] = user.Id;
            row["Name"] = user.Name;
            row["Password"] = user.Password;
            row["Email"] = user.Email;
            UsersDtable.Rows.Add(row);
        }

        public void UpdateUserHandler(User user)
        {
            if (user == null)
                return;
            
            selected_user.Row["Id"] = user.Id;
            selected_user.Row["Name"] = user.Name;
            selected_user.Row["Password"] = user.Password;
            selected_user.Row["Email"] = user.Email;
        }

        public void DeleteUserHandler(DataRowView rowUser)
        {
            if (rowUser == null)
                return;

            foreach (var user in User.Items)
                if (user.Id == (int) rowUser.Row["Id"])
                {
                    user.Delete();
                    break;
                }

            UsersDtable.Rows.Remove(rowUser.Row);
        }

        #endregion

        private readonly DelegateCommand<User> _addUser;
        private readonly DelegateCommand<User> _editUser;
        private readonly DelegateCommand<DataRowView> _deleteUser;

        public DelegateCommand<User> AddUser
        {
            get { return _addUser; }
        }

        public DelegateCommand<User> EditUser
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

        public DataTable Get_users()
        {
            var ds = new DataTable();
            ds.Columns.Add("Id", typeof(int));
            ds.Columns.Add("Name");
            ds.Columns.Add("Password");
            ds.Columns.Add("Email");

            foreach (var user in User.Items)
            {
                if (user.GetType() == typeof(User))
                    ds.Rows.Add(user.Id, user.Name, user.Password, user.Email);
            }
            return ds;
        }
        #endregion
    }   
}

