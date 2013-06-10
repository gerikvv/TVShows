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
        
        public void Color_rating(Class_tvshow tvshow)
        {
            float rating;
            float.TryParse(tvshow.Overall_rating.Replace('.', ','), out rating);
            if (rating >= 7)
                TVDockPanelControl.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 55, 0xA3, 32));
            if (rating >= 5 && rating < 7)
                TVDockPanelControl.tbRatingValue.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 00, 00, 0xFF));
        }

        private void Random_click(object sender, RoutedEventArgs e)
        {
            Random_tv();
        }

        public void Random_tv()
        {
            var rand = new Random();
            var i = rand.Next(0, Class_tvshow.Items.Count);

            var tvshow = Class_tvshow.Items[i];

            if (tvshow.Name == TVDockPanelControl.TbName.Text)
                tvshow = i + 1 < Class_tvshow.Items.Count ? Class_tvshow.Items[i + 1] : Class_tvshow.Items[0];

            Color_rating(tvshow);
            DataContext = tvshow;
        }
	}
}