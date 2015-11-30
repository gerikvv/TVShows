using System;
using System.Collections.ObjectModel;
using System.Data;

namespace TVShows.Data.Interfaces
{
    public interface IRepository<T>
    {
        ConnectionState State { get; set; }

        ObservableCollection<T> GetAllObjects();
        int GetId();

        void Update(T obj);

        void Save(T obj);

        void Delete(Int32 idObj);
    }
}
