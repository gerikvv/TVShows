using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using Syncfusion.Windows.Shared;
using TVShows.Data;
using TVShows.Data.Classes;

namespace TVShows.ViewModel
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

            var mainWindow = (Main_window)Application.Current.MainWindow;

            if (mainWindow.Man.GetType() == typeof(User))
            {
                foreach (var classFavoritesMan in Favorites_and_user.Items)
                    if (classFavoritesMan.TvFavor.Name == (string) favorites_man.Row["Name"] &&
                        classFavoritesMan.TvFavor.Year.ToString() == (string) favorites_man.Row["Year"])
                    {
                        classFavoritesMan.Delete();
                        break;
                    }
            }
            else
            {
                foreach (var classFavoritesMan in Favorites_and_admin.Items)
                    if (classFavoritesMan.TvFavor.Name == (string) favorites_man.Row["Name"] &&
                        classFavoritesMan.TvFavor.Year.ToString() == (string) favorites_man.Row["Year"])
                    {
                        classFavoritesMan.Delete();
                        break;
                    }
            }

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
            ds.Columns.Add("Director");

            var mainWindow = (Main_window)Application.Current.MainWindow;

            var tvshows = new List<Tvshow>();

            if (mainWindow.Man.GetType() == typeof(User))
            {
                foreach (var favoritesAndUser in Favorites_and_user.Items)
                {
                    if (favoritesAndUser.IdUser == mainWindow.Man.Id)
                        tvshows.Add(Tvshow.Get_obj(favoritesAndUser.IdTVShow));
                }
            }
            else
            {
                foreach (var favoritesAndAdmin in Favorites_and_admin.Items)
                {
                    if (favoritesAndAdmin.IdAdmin== mainWindow.Man.Id)
                        tvshows.Add(Tvshow.Get_obj(favoritesAndAdmin.IdTVShow));
                }
            }

            foreach (var tv in tvshows)
                ds.Rows.Add(tv.Id, tv.Name, tv.Year, tv.Country, tv.Slogan, tv.Script_writer, tv.Producer,
                    tv.Budget, tv.Global_charges, tv.Time, tv.Overall_rating, tv.Name_image, tv.Director);

            return ds;
        }
        #endregion
    }
}

