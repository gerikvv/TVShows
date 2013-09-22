using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using Syncfusion.Windows.Shared;
using TVShows.Data;

namespace TVShows
{
    public class FavoritesViewModel : TVShowViewModel
    {
        #region Constructor

        public FavoritesViewModel()
        {
            TVDtable = this.Get_tvshows();
            _deleteFavoritesMan = new DelegateCommand<DataRowView>(DeleteFavoritesManHandler);
        }
        #endregion

        #region Command Handler

        public void DeleteFavoritesManHandler(DataRowView favorites_man)
        {
            if (favorites_man == null)
                return;

            foreach (var classFavoritesMan in Class_favorites_and_user.Items)
                if (classFavoritesMan.Tvshow.Name == (string)favorites_man.Row["Name"] &&
                    classFavoritesMan.Tvshow.Year.ToString() == (string)favorites_man.Row["Year"])
                    classFavoritesMan.Delete(Class_favorites_and_user.Dtable, classFavoritesMan.Id);

            TVDtable.Rows.Remove(favorites_man.Row);
        }

        #endregion

        private readonly DelegateCommand<DataRowView> _deleteFavoritesMan;
        
        public DelegateCommand<DataRowView> DeleteFavoritesMan
        {
            get { return _deleteFavoritesMan; }
        }

        #region Properties

        private DataTable tvDtable;

        public DataTable TVDtable
        {
            get { return tvDtable; }
            set { tvDtable = value; }
        }

        private DataRowView selected_favorites_man;

        public DataRowView SelectedFavoritesMan
        {
            get { return selected_favorites_man; }
            set
            {
                selected_favorites_man = value;
                RaisePropertyChanged("SelectedFavoritesMan");
            }
        }

        #endregion

        #region Methods

        public override sealed DataTable Get_tvshows()
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

            var mainWindow = (Main_window)Application.Current.MainWindow;

            var tvshows = new List<Class_tvshow>(); 
            foreach (var favoritesAndMan in Class_favorites_and_user.Items)
            {
                if (favoritesAndMan.IdUser == mainWindow.Man.Id)
                    tvshows.Add(Class_tvshow.Get_obj(favoritesAndMan.IdTVShow));
            }

            foreach (var tv in tvshows)
                ds.Rows.Add(tv.Id, tv.Name, tv.Year, tv.Country, tv.Slogan, tv.Script_writer, tv.Producer,
                    tv.Budget, tv.Global_charges, tv.Time, tv.Overall_rating, tv.Name_image);

            return ds;
        }
        #endregion
    }
}

