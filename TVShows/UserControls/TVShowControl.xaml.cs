﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TVShows.Data.Classes;

namespace TVShows.UserControls
{
	/// <summary>
	/// Interaction logic for RandomTVShow.xaml
	/// </summary>
	public partial class TVShowControl : UserControl
	{
	    private static TVShowControl tvShowControl;
        public TVShowControl() { this.InitializeComponent(); }

        public static TVShowControl Instance()
        {
            return tvShowControl ?? (tvShowControl = new TVShowControl());
        }

        public void Color_rating(Tvshow tvshow, TVDockPanelControl dock_panel)
        {
            var rating = tvshow.Overall_rating;
            if (rating >= 7)
                dock_panel.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 55, 0xA3, 32));
            if (rating >= 5 && rating < 7)
                dock_panel.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 00, 00, 0xFF));
        }

        private void Random_click(object sender, RoutedEventArgs e)
        {
            TbTitle.Text = "Случайный фильм";
            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Cap.Show_random_tv(this);
        }

        public void Random_tv(TVDockPanelControl dock_panel)
        {
            var rand = new Random();
            var i = rand.Next(0, Tvshow.Items.Count);

            var tvshow = Tvshow.Items[i];

            if (PageTransitionControl.Current_page != null && tvshow == PageTransitionControl.Current_page.DataContext)
                tvshow = i + 1 < Tvshow.Items.Count ? Tvshow.Items[i + 1] : Tvshow.Items[0];
            
            dock_panel.DataContext = tvshow;
            Color_rating(tvshow, dock_panel);
        }
	}
}