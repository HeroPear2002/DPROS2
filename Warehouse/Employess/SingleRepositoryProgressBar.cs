using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Employess
{
    internal class SRProgressBarHelper
    {
        private GridColumn Column;
        private GridView View;

        public SRProgressBarHelper(GridColumn column)
        {
            this.Column = column;
            View = this.Column.View as GridView;
            View.ShownEditor += View_ShownEditor;
            View.CustomDrawCell += View_CustomDrawCell;
        }
        private void View_ShownEditor(object sender, EventArgs e)
        {
            if (View.FocusedColumn != Column)
                return;
            ProgressBarControl pbc = View.ActiveEditor as ProgressBarControl;
            int percent = Convert.ToInt16(pbc.EditValue);
            if (percent < 60)
            {
                pbc.Properties.EndColor = Color.Red;
                pbc.Properties.StartColor = Color.Red;
            }
            else if (percent < 80)
            {
                pbc.Properties.EndColor = Color.Orange;
                pbc.Properties.StartColor = Color.Orange;
            }
            else if (percent < 100)
            {
                pbc.Properties.EndColor = Color.Yellow;
                pbc.Properties.StartColor = Color.Yellow;
            }
            else if (percent == 100)
            {
                pbc.Properties.EndColor = Color.SpringGreen;
                pbc.Properties.StartColor = Color.SpringGreen;
            }
            else
            {
                pbc.Properties.EndColor = Color.GreenYellow;
                pbc.Properties.StartColor = Color.GreenYellow;
            }
        }

        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == Column)
            {
                int percent = Convert.ToInt16(e.CellValue);
                ProgressBarViewInfo vi = (e.Cell as GridCellInfo).ViewInfo as ProgressBarViewInfo;
                if (percent < 60)
                {
                    vi.ProgressInfo.EndColor = Color.Red;
                    vi.ProgressInfo.StartColor = Color.Red;
                }
                else if (percent < 80)
                {
                    vi.ProgressInfo.EndColor = Color.Orange;
                    vi.ProgressInfo.StartColor = Color.Orange;
                }
                else if (percent < 100)
                {
                    vi.ProgressInfo.EndColor = Color.Yellow;
                    vi.ProgressInfo.StartColor = Color.Yellow;
                }
                else if (percent == 100)
                {
                    vi.ProgressInfo.EndColor = Color.SpringGreen;
                    vi.ProgressInfo.StartColor = Color.SpringGreen;
                }
                else 
                {
                    vi.ProgressInfo.EndColor = Color.GreenYellow;
                    vi.ProgressInfo.StartColor = Color.GreenYellow;
                }
            }
        }
    }
}
