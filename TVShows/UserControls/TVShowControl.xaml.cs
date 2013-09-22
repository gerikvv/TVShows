using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TVShows.Data;

namespace TVShows
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

        public void Color_rating(Class_tvshow tvshow, TVDockPanelControl dock_panel)
        {
            var rating = tvshow.Overall_rating;
            if (rating >= 7)
                dock_panel.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 55, 0xA3, 32));
            if (rating >= 5 && rating < 7)
                dock_panel.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 00, 00, 0xFF));
        }

        private void Random_click(object sender, RoutedEventArgs e)
        {
            //var tvDockPanelControl = new TVDockPanelControl();
            //Random_tv(tvDockPanelControl);
            
            //var mainWindow = (Main_window)Application.Current.MainWindow;
            //if (mainWindow.Man != null) tvDockPanelControl.Star.Visibility = Visibility.Visible;

            //this.PageTransitionControl.Show_page(tvDockPanelControl);

            var mainWindow = (Main_window)Application.Current.MainWindow;
            mainWindow.Cap.Show_random_tv(this);
        }

        public void Random_tv(TVDockPanelControl dock_panel)
        {
            var rand = new Random();
            var i = rand.Next(0, Class_tvshow.Items.Count);

            var tvshow = Class_tvshow.Items[i];

            if (PageTransitionControl.Current_page != null && tvshow == PageTransitionControl.Current_page.DataContext)
                tvshow = i + 1 < Class_tvshow.Items.Count ? Class_tvshow.Items[i + 1] : Class_tvshow.Items[0];
            
            dock_panel.DataContext = tvshow;
            Color_rating(tvshow, dock_panel);
        }
	}
}