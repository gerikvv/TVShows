using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TVShows
{
    /// <summary>
    /// Логика взаимодействия для TVDockPanelControl.xaml
    /// </summary>
    public partial class TVDockPanelControl : UserControl
    {
        public TVDockPanelControl()
        {
            InitializeComponent();
        }


        Stack<UserControl> pages = new Stack<UserControl>();

        public UserControl Current_page { get; set; }

        public void Show_page(UserControl new_page)
        {
            pages.Push(new_page);

            Task.Factory.StartNew(Show_new_page);
        }

        void Show_new_page()
        {
            Dispatcher.Invoke((Action)delegate
            {
                if (contentPresenter.Content != null)
                {
                    UserControl oldPage = contentPresenter.Content as UserControl;

                    if (oldPage != null)
                    {
                        oldPage.Loaded -= New_page_loaded;

                        Unload_page(oldPage);
                    }
                }
                else
                {
                    Show_next_page();
                }

            });
        }

        void Show_next_page()
        {
            UserControl newPage = pages.Pop();

            newPage.Loaded += New_page_loaded;

            contentPresenter.Content = newPage;
        }

        void Unload_page(UserControl page)
        {
            Storyboard hidePage = ((Storyboard)Resources[string.Format("{0}Out", "GrowAndFade")]).Clone();

            hidePage.Completed += Hide_page_completed;

            hidePage.Begin(contentPresenter);
        }

        void New_page_loaded(object sender, RoutedEventArgs e)
        {
            Storyboard showNewPage = Resources[string.Format("{0}In", "GrowAndFade")] as Storyboard;

            showNewPage.Begin(contentPresenter);

            Current_page = sender as UserControl;
        }

        void Hide_page_completed(object sender, EventArgs e)
        {
            contentPresenter.Content = null;

            Show_next_page();
        }
    }
}
