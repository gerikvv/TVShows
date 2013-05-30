using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TVShows.Data.ViewModel
{
    class UserViewModel
    {
        private ObservableCollection<Class_user> users = new ObservableCollection<Class_user>();

        public ObservableCollection<Class_user> Persons
        {
            get { return users; }
            set { users = value; }
        }
    }
}
