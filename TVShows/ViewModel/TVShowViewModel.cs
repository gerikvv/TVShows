using System;
using System.Data;
using Syncfusion.Windows.Shared;
using TVShows.Data;

namespace TVShows
{
    public class TVShowViewModel : NotificationObject
    {
        #region Constructor

        public TVShowViewModel()
        {
            TVDtable = Get_tvshows();
            _addTV = new DelegateCommand<Class_tvshow>(AddTVHandler);
            _editTV = new DelegateCommand<Class_tvshow>(UpdateTVHandler);
            _deleteTV = new DelegateCommand<DataRowView>(DeleteTVHandler);
        }
        #endregion

        #region Command Handler

        public void AddTVHandler(Class_tvshow tv)
        {
            if (tv == null)
                return;

            Class_tvshow.Items.Add(tv);
            tv.Save();

            var row = TVDtable.NewRow();
            row["Id"] = tv.Id;
            row["Name"] = tv.Name;
            row["Year"] = tv.Year;
            row["Country"] = tv.Country;
            row["Slogan"] = tv.Slogan;
            row["Script_writer"] = tv.Script_writer;
            row["Producer"] = tv.Producer;
            row["Budget"] = tv.Budget;
            row["Global_charges"] = tv.Global_charges;
            row["Time"] = tv.Time;
            row["Overall_rating"] = tv.Overall_rating;
            row["Name_image"] = tv.Name_image;
            row["Director"] = tv.Director;
            TVDtable.Rows.Add(row);
        }

        public void UpdateTVHandler(Class_tvshow tv)
        {
            if (tv == null)
                return;

            selected_tv.Row["Id"] = tv.Id;
            selected_tv.Row["Name"] = tv.Name;
            selected_tv.Row["Year"] = tv.Year;
            selected_tv.Row["Country"] = tv.Country;
            selected_tv.Row["Slogan"] = tv.Slogan;
            selected_tv.Row["Script_writer"] = tv.Script_writer;
            selected_tv.Row["Producer"] = tv.Producer;
            selected_tv.Row["Budget"] = tv.Budget;
            selected_tv.Row["Global_charges"] = tv.Global_charges;
            selected_tv.Row["Time"] = tv.Time;
            selected_tv.Row["Overall_rating"] = tv.Overall_rating;
            selected_tv.Row["Name_image"] = tv.Name_image;
            selected_tv.Row["Director"] = tv.Director;

            tv.Update();
            Class_tvshow.Items.Clear();
            Class_tvshow.Init_tv_show();
        }

        public void DeleteTVHandler(DataRowView tv)
        {
            if (tv == null)
                return;

            foreach (var classTv in Class_tvshow.Items)
                if (classTv.Id == (int) tv.Row["Id"])
                {
                    classTv.Delete();
                    break;
                }

            TVDtable.Rows.Remove(tv.Row);
        }

        #endregion

        private readonly DelegateCommand<Class_tvshow> _addTV;
        private readonly DelegateCommand<Class_tvshow> _editTV;
        private readonly DelegateCommand<DataRowView> _deleteTV;

        public DelegateCommand<Class_tvshow> AddTV
        {
            get { return _addTV; }
        }

        public DelegateCommand<Class_tvshow> EditTV
        {
            get { return _editTV; }
        }

        public DelegateCommand<DataRowView> DeleteTV
        {
            get { return _deleteTV; }
        }

        #region Properties

        private DataTable tvDtable;

        public DataTable TVDtable
        {
            get { return tvDtable; }
            set { tvDtable = value; }
        }

        private DataRowView selected_tv;

        public DataRowView SelectedTV
        {
            get { return selected_tv; }
            set
            {
                selected_tv = value;
                RaisePropertyChanged("SelectedTV");
            }
        }

        #endregion

        #region Methods

        public virtual DataTable Get_tvshows()
        {
            var ds = new DataTable();
            ds.Columns.Add("Id", typeof(int));
            ds.Columns.Add("Name");
            ds.Columns.Add("Year");
            ds.Columns.Add("Country");
            ds.Columns.Add("Slogan");
            ds.Columns.Add("Script_writer");
            ds.Columns.Add("Producer");
            ds.Columns.Add("Budget", typeof(int));
            ds.Columns.Add("Global_charges", typeof(int));
            ds.Columns.Add("Time", typeof(DateTime));
            ds.Columns.Add("Overall_rating");
            ds.Columns.Add("Name_image");
            ds.Columns.Add("Director");

            foreach (var tv in Class_tvshow.Items)
                ds.Rows.Add(tv.Id, tv.Name, tv.Year, tv.Country, tv.Slogan, tv.Script_writer, tv.Producer,
                    tv.Budget, tv.Global_charges, tv.Time, tv.Overall_rating, tv.Name_image, tv.Director);

            return ds;
        }
        #endregion
    }
}

