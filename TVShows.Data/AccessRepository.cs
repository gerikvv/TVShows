using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using TVShows.Data.Interfaces;

namespace TVShows.Data
{
    public class Access_repository<T> : IRepository<T> where T : IBase, new()
    {
        private static ConnectionState state;
        public ConnectionState State { get { return state; } set { state = value; } }

        const string ConnectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                        data source = ..//..//..//db/SMonitoring DataBase.accdb";

        private static readonly OleDbConnection _connection = new OleDbConnection(ConnectionString);
        private static OleDbCommand insert;
        private static OleDbCommand update;
        private static OleDbCommand delete;
        private static OleDbCommand select;
        private static DataTable table;

        private static string _dtable;
        
        public Access_repository(string dtable)
        {
            _dtable = dtable;
        }

        private static void Initialize()
        {
            _connection.ConnectionString = ConnectionString;
            var adapter = new OleDbDataAdapter();
            var cmdbuilder = new OleDbCommandBuilder { QuotePrefix = "[", QuoteSuffix = "]" };
            cmdbuilder.RefreshSchema();
            table = new DataTable(_dtable);

            using (_connection)
            {
                select = new OleDbCommand(string.Format("SELECT * FROM {0}", _dtable), _connection);
                adapter.SelectCommand = select;
                cmdbuilder.DataAdapter = adapter;
                Get_commands(adapter, cmdbuilder);
                adapter.Fill(table);
            }
        }

        private static void Initialize_table()
        {
            if (table == null) Initialize();
            if(table.TableName != _dtable) Initialize();
            _connection.ConnectionString = ConnectionString;
        }

        public ObservableCollection<T> GetAllObjects()
        {
            Initialize_table();

            var tcoll = new ObservableCollection<T>();
            select.Connection = _connection;
            _connection.Open();
            State = _connection.State;
            using (_connection)
            {
                OleDbDataReader reader = select.ExecuteReader();
                if (reader != null)

                    while (reader.Read())
                    {
                        var temp = new object[reader.FieldCount];
                        reader.GetValues(temp);

                        var t = new T {Objparams = temp};

                        tcoll.Add(t);
                    }
                _connection.Close();
                State = _connection.State;
            }
            return tcoll;
        }

        public void Update(T obj)
        {
            Initialize_table();

            for (int i = 0; i < obj.Objparams.Length - 1; i++)
                update.Parameters[string.Format("p{0}", i + 1)].Value = obj.Objparams[i + 1];
            update.Parameters[string.Format("p{0}", obj.Objparams.Length)].Value = obj.Objparams[0];

            using (_connection)
            {
                _connection.Open();
                update.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Save(T obj)
        {
            Initialize_table();

            for (int i = 0; i < insert.Parameters.Count; i++)
                insert.Parameters[string.Format("p{0}", i + 1)].Value = obj.Objparams[i + 1];

            using (_connection)
            {
                _connection.Open();
                insert.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public virtual void Delete(Int32 idObj)
        {
            Initialize_table();

            using (_connection)
            {
                _connection.Open();
                delete.Parameters[string.Format("p{0}", 1)].Value = idObj;
                delete.ExecuteNonQuery();
            }
            _connection.Close();
        }

        private static void Get_commands(OleDbDataAdapter adapter, OleDbCommandBuilder cmdbuilder)
        {
            adapter.InsertCommand = cmdbuilder.GetInsertCommand();
            adapter.UpdateCommand = cmdbuilder.GetUpdateCommand();
            adapter.DeleteCommand = cmdbuilder.GetDeleteCommand();
            delete = adapter.DeleteCommand;
            delete.CommandText = Receive_request(adapter.DeleteCommand.CommandText);
            insert = adapter.InsertCommand;
            update = adapter.UpdateCommand;
            update.CommandText = Receive_request(adapter.UpdateCommand.CommandText);
        }

        private static string Receive_request(string request)
        {
            request = request.Remove(request.IndexOf('('), 1);
            request = request.Remove(request.IndexOf(" AND"));
            return request;
        }
    }
}
