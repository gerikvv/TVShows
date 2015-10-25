using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Syncfusion.Windows.Shared;
using TVShows.Data.Interfaces;

namespace TVShows.Data
{
    public class Class_base<T> : NotificationObject, IBase, INotifyPropertyChanged where T : Class_base<T>, new()
    {
        private static ObservableCollection<T> _items = new ObservableCollection<T>();
        private static IRepository<T> _repository;
        public Object[] objects;
        private int _id;
        private string _name;

        public static ObservableCollection<T> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public static IRepository<T> Repository { get { return _repository; } set { _repository = value; } } 

        public virtual Object[] Objparams { get; set; }

        public int Id
        {
            get { return _id; } 
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        protected Class_base()
        {
        }

        protected Class_base(string name)
            : this()
        {
            //Items.Add((T)this);
            Name = name;
        }

        public static T Get_obj(int idObj)
        {
            return Items.FirstOrDefault(item => item.Id == idObj);
        }

        public virtual void Save()
        {
            Repository.Save((T)this);
            Items.Add((T)this);
            Id = Repository.GetAllObjects().Last().Id;
        }

        public virtual void Delete()
        {
            Items.Remove((T) this);
            Repository.Delete(Id);
        }

        public virtual void Update()
        {
            Repository.Update((T)this);
            Items[Items.IndexOf(Items.FirstOrDefault(elem => elem.Id == Id))] = (T)this;
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected void On_property_changed(string paramName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(paramName));
            }
        }
    }
}
