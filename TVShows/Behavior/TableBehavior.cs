using System;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Interactivity;

namespace TVShows
{
    class TableBehavior : Behavior<GridDataControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
            this.AssociatedObject.ModelLoaded += new EventHandler(AssociatedObject_ModelLoaded);
        }

        void AssociatedObject_ModelLoaded(object sender, EventArgs e)
        {
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 58;
        }

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e != null)
            {
                var identity = ((GridDataStyleInfo)e.Style).CellIdentity;
                if (identity == null || identity.Column == null)
                    return;
                if (identity.TableCellType == GridDataTableCellType.RecordCell)
                {
                    if (identity.Column.MappingName == "Name_image")
                    {
                        e.Style.ShowTooltip = true;
                        e.Style.TooltipTemplateKey = "myTooltipTemplate";
                    }
                }
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
            this.AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
        }
    }
}
