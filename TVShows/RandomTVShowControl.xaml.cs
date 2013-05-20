using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TVShows.Data;

namespace TVShows
{
	/// <summary>
	/// Interaction logic for RandomTVShow.xaml
	/// </summary>
	public partial class RandomTVShowControl : UserControl
	{
		public RandomTVShowControl()
		{
			this.InitializeComponent();
		}

        private void Button1_click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            var i = rand.Next(0, Class_tvshow.Items.Count);
            if (i >= 0)
            {
                var tvshow = Class_tvshow.Items[i];
                DataContext = tvshow;
            }
        }
	}
}