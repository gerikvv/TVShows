using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace TVShows.Data
{
    public abstract class Class_base<T> where T : Class_base<T>
    {
        private static List<T> items = new List<T>();

        public static List<T> Items
        {
            get { return items; }
            set { items = value; }
        }

        public Object[] objects;
        public virtual Object[] Objparams { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

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

        public static void Initialize(string dtable)
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
                Get_commands(adapter, cmdbuilder, dtable);
                adapter.Fill(table);
            }
        }

        public void Save(string dtable)
        {
            if (table == null) Initialize(dtable);
            if (table.TableName != dtable) Initialize(dtable);
            _connection.ConnectionString = ConnectionString;
            
            var command = insert;
            var len = command.Parameters.Count;
            
            for (int i = 0; i < len; i++)
                command.Parameters[string.Format("p{0}", i + 1)].Value = Objparams[i+1];
            
            using (_connection)
            {
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Update (string dtable)
        {
            if (table == null) Initialize(dtable);
            if (table.TableName != dtable) Initialize(dtable);
            _connection.ConnectionString = ConnectionString;

            for (int i = 0; i < Objparams.Length-1; i++)
                update.Parameters[string.Format("p{0}", i + 1)].Value = Objparams[i+1];
            update.Parameters[string.Format("p{0}", Objparams.Length)].Value = Objparams[0];

            for (int i = Objparams.Length + 1; i < update.Parameters.Count; i++)
                update.Parameters[string.Format("p{0}", i + 1)].Value = 1;
            
            using (_connection)
            {
                _connection.Open();
                update.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void Delete(string dtable, Int32 id_obj)
        {
            if (table == null) Initialize(dtable);
            if (table.TableName != dtable) Initialize(dtable);
            _connection.ConnectionString = ConnectionString;

            using (_connection)
            {
                _connection.Open();
                delete.Parameters["@ID"].Value = id_obj;
                delete.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public List<T> Get(string dtable)
        {
            if (table == null) Initialize(dtable);
            if (table.TableName != dtable) Initialize(dtable);
            _connection.ConnectionString = ConnectionString;

            var tlist = new List<T>();
            select.Connection = _connection;
            _connection.Open();
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
            }
            return tlist;
        }
        
        private static void Get_commands(OleDbDataAdapter adapter, OleDbCommandBuilder cmdbuilder, string dtable)
        {
            adapter.InsertCommand = cmdbuilder.GetInsertCommand();
            adapter.UpdateCommand = cmdbuilder.GetUpdateCommand();
            adapter.DeleteCommand = new OleDbCommand(string.Format("DELETE FROM {0} WHERE `ID`=@ID", dtable), _connection);
            insert = adapter.InsertCommand;
            update = adapter.UpdateCommand;
            delete = adapter.DeleteCommand;
            delete.Parameters.Add(new OleDbParameter("@ID", ""));
        }
    }
}
