using System;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;

namespace TVShows
{
    class RowBehavior : Behavior<GridDataControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.ModelLoaded += new EventHandler(AssociatedObject_ModelLoaded);
        }

        void AssociatedObject_ModelLoaded(object sender, EventArgs e)
        {
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 58;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
        }
    }
}
