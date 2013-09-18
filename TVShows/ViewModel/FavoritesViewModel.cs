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
        #region Methods

        public override DataTable Get_tvshows()
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
            foreach (var favoritesAndMan in Class_favorites_and_man.Items)
            {
                if (favoritesAndMan.IdMan == mainWindow.Man.Id)
                    tvshows.Add(Class_tvshow.Get_tv(favoritesAndMan.IdTVShow));
            }

            foreach (var tv in tvshows)
                ds.Rows.Add(tv.Id, tv.Name, tv.Year, tv.Country, tv.Slogan, tv.Script_writer, tv.Producer,
                    tv.Budget, tv.Global_charges, tv.Time, tv.Overall_rating, tv.Name_image);

            return ds;
        }
        #endregion
    }
}

