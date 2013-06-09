using System;
using System.Data;
using Syncfusion.Windows.Shared;
using TVShows.Data;

namespace TVShows
{
    public class UserManipulatorViewModel : NotificationObject
    {
        #region Properties

        Class_user user = new Class_user();

        public Class_user User
        {
            get { return user; }
            set { user = value; }
        }

        public int Id
        {
            get { return User.Id; }
            set
            {
                User.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return User.Name; }
            set
            {
                User.Name = value;
                RaisePropertyChanged("Name");
            }
        }
        
        public string Password
        {
            get { return User.Password; }
            set
            {
                User.Password = value;
                RaisePropertyChanged("Password");
            }
        }

        public string Email
        {
            get { return User.Email; }
            set
            {
                User.Email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string SaveButtonContent
        {
            get;
            set;
        }

        #endregion

        #region Constructor & Methods

        public UserManipulatorViewModel(DataRowView employee)
        {
            CloneCustomers(employee);
        }

        public UserManipulatorViewModel(DataRowView employee, bool is_in_edit)
        {
            SaveCommand = new DelegateCommand<Class_user>(Save);
            SaveButtonContent = is_in_edit ? "Save" : "Add";
            if (is_in_edit)
                CloneCustomers(employee);
        }

        private void CloneCustomers(DataRowView employee)
        {
            Id = Int32.Parse(employee["Id"].ToString());
            Name = employee["Name"].ToString();
            Password = employee["Password"].ToString();
            Email = employee["Email"].ToString();
        }

        #endregion

        #region Save Command

        public DelegateCommand<Class_user> SaveCommand
        {
            get;
            set;
        }
        
        private void Save(object obj)
        {

        }
        #endregion
    }
}
