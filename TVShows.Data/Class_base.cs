using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace TVShows.Data
{
    public abstract class Class_base<T> : NotificationObject, INotifyPropertyChanged where T : Class_base<T>
    {
        private static List<T> items = new List<T>();

        public static List<T> Items
        {
            get { return items; }
            set { items = value; }
        }

        public Object[] objects;
        public virtual Object[] Objparams { get; set; }

        private int id;
        public int Id
        {
            get { return id; } 
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private static ConnectionState state;
        public ConnectionState State { get { return state; } set { state = value; } }

        protected Class_base()
        {
        }

        protected Class_base(string name)
            : this()
        {
            items.Add((T)this);
            Name = name;
        }

        const string ConnectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                        data source = SMonitoring DataBase.accdb";

        private static readonly OleDbConnection _connection = new OleDbConnection(ConnectionString);
        private static OleDbCommand insert;
        private static OleDbCommand update;
        private static OleDbCommand delete;
        private static OleDbCommand select;
        private static DataTable table;

        private static void Initialize(string dtable)
        {
            _connection.ConnectionString = ConnectionString;
            var adapter = new OleDbDataAdapter();
            var cmdbuilder = new OleDbCommandBuilder {QuotePrefix = "[", QuoteSuffix = "]"};
            cmdbuilder.RefreshSchema();
            table = new DataTable(dtable);
            
            using (_connection)
            {
                select = new OleDbCommand(string.Format("SELECT * FROM {0}", dtable), _connection);
                adapter.SelectCommand = select;
                cmdbuilder.DataAdapter = adapter;
                Get_commands(adapter, cmdbuilder);
                adapter.Fill(table);
            }
        }

        private static void Initialize_table (string dtable)
        {
            if (table == null) Initialize(dtable);
            if (table.TableName != dtable) Initialize(dtable);
            _connection.ConnectionString = ConnectionString;
        }

        public void Save(string dtable)
        {
            Initialize_table(dtable);
            
            for (int i = 0; i < insert.Parameters.Count; i++)
                insert.Parameters[string.Format("p{0}", i + 1)].Value = Objparams[i + 1];
            
            using (_connection)
            {
                _connection.Open();
                insert.ExecuteNonQuery();
                _connection.Close();
            }

            var elements = Get(dtable);
            Id = elements[elements.Count - 1].Id;
        }

        public void Update(string dtable)
        {
            Initialize_table(dtable);
            
            for (int i = 0; i < Objparams.Length - 1; i++)
                update.Parameters[string.Format("p{0}", i + 1)].Value = Objparams[i + 1];
            update.Parameters[string.Format("p{0}", Objparams.Length)].Value = Objparams[0];

            using (_connection)
            {
                _connection.Open();
                update.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Delete(string dtable, Int32 id_obj)
        {
            Initialize_table(dtable);

            using (_connection)
            {
                _connection.Open();
                delete.Parameters[string.Format("p{0}", 1)].Value = id_obj;
                delete.ExecuteNonQuery();
            }
            _connection.Close();

            Items = Get(dtable);
        }

        public List<T> Get(string dtable)
        {
            Initialize_table(dtable);

            var tlist = new List<T>();
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
                        Objparams = temp;
                        var s = (T)MemberwiseClone();
                        tlist.Add(s);
                    }
                _connection.Close();
                State = _connection.State;
            }
            return tlist;
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

        private static string Receive_request (string request)
        {
            request = request.Remove(request.IndexOf('('), 1);
            request = request.Remove(request.IndexOf(" AND"));
            return request;
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected void On_property_changed(string param_name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(param_name));
            }
        }
    }
}
