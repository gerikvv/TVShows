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
		public TVShowControl()
		{
			this.InitializeComponent();
		}
        
        public void Color_rating(Class_tvshow tvshow, TVDockPanelControl dock_panel)
        {
            var rating = tvshow.Overall_rating;
            if (rating >= 7)
                dock_panel.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 55, 0xA3, 32));
            if (rating >= 5 && rating < 7)
                dock_panel.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 00, 00, 0xFF));
        }

        public void Color_rating(Class_tvshow tvshow)
        {
            var rating = tvshow.Overall_rating;
            if (rating >= 7)
                TVDockPanelControl.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 55, 0xA3, 32));
            if (rating >= 5 && rating < 7)
                TVDockPanelControl.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 00, 00, 0xFF));
        }

        private void Random_click(object sender, RoutedEventArgs e)
        {
            var tvDockPanelControl = new TVDockPanelControl();
            /*var tvshow = */Random_tv(tvDockPanelControl);

            //Color_rating(tvshow, tvDockPanelControl);
            //DataContext = tvshow;

            var mainWindow = (Main_window)Application.Current.MainWindow;
            if (mainWindow.Man != null) tvDockPanelControl.Star.Visibility = Visibility.Visible;

            this.TVDockPanelControl.Show_page(tvDockPanelControl);
        }

        public Class_tvshow Random_tv(TVDockPanelControl dock_panel)
        {
            var rand = new Random();
            var i = rand.Next(0, Class_tvshow.Items.Count);

            var tvshow = Class_tvshow.Items[i];

            if (tvshow.Name == dock_panel.TbName.Text)
                tvshow = i + 1 < Class_tvshow.Items.Count ? Class_tvshow.Items[i + 1] : Class_tvshow.Items[0];
            
            //if (is_random_click) return tvshow;

            DataContext = tvshow;
            Color_rating(tvshow, dock_panel);

            return null;
        }
	}
}