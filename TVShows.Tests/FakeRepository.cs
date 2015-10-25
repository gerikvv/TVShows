using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TVShows.Data.Interfaces;

namespace TVShows.Tests
{
    public class Fake_repository<T> : IRepository<T> where T : IBase
    {
        private const ConnectionState state = ConnectionState.Closed;
        private static List<T> _items = new List<T>();

        public ConnectionState State { get { return state; } set { } }

        public ObservableCollection<T> GetAllObjects()
        {
            return new ObservableCollection<T>(_items);
        }

        public void Update(T obj)
        {
            _items[_items.IndexOf(_items.FirstOrDefault(elem => elem.Id == obj.Id))] = obj;
        }

        public void Save(T obj)
        {
            obj.Id = _items.Count;
            _items.Add(obj);
        }

        public void Delete(int idObj)
        {
            _items.Remove(_items.FirstOrDefault(elem => elem.Id == idObj));
        }
    }
}
