using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Employess
{
    internal class DRProgressBarHelper
    {
        private GridColumn Column;
        private GridView View;
        private RepositoryItemProgressBar prbLess60;
        private RepositoryItemProgressBar prbLess80;
        private RepositoryItemProgressBar prbLess99;
        private RepositoryItemProgressBar prbLess100;
        private RepositoryItemProgressBar prbLess101;

        public DRProgressBarHelper(GridColumn column)
        {
            PrbInit();
            this.Column = column;
            View = this.Column.View as GridView;
            View.CustomRowCellEdit += View_CustomRowCellEdit;
        }
        private void PrbInit()
        {
            prbLess60 = new RepositoryItemProgressBar();
            prbLess60.StartColor = Color.Red;
            prbLess60.EndColor = Color.Red;
            prbLess60.ShowTitle = true;
            prbLess60.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess60.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess60.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess80 = new RepositoryItemProgressBar();
            prbLess80.StartColor = Color.Orange;
            prbLess80.EndColor = Color.Orange;
            prbLess80.ShowTitle = true;
            prbLess80.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess80.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess80.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess99 = new RepositoryItemProgressBar();
            prbLess99.StartColor = Color.Yellow;
            prbLess99.EndColor = Color.Yellow;
            prbLess99.ShowTitle = true;
            prbLess99.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess99.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess99.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess100 = new RepositoryItemProgressBar();
            prbLess100.StartColor = Color.SpringGreen;
            prbLess100.EndColor = Color.SpringGreen;
            prbLess100.ShowTitle = true;
            prbLess100.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess100.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess100.LookAndFeel.UseDefaultLookAndFeel = false;

            prbLess101 = new RepositoryItemProgressBar();
            prbLess101.StartColor = Color.GreenYellow;
            prbLess101.EndColor = Color.GreenYellow;
            prbLess101.ShowTitle = true;
            prbLess101.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            prbLess101.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            prbLess101.LookAndFeel.UseDefaultLookAndFeel = false;
        }

        private void View_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == Column)
            {
                int percent = Convert.ToInt16(e.CellValue);
                if (percent < 60)
                    e.RepositoryItem = prbLess60;
                else if (percent < 80)
                    e.RepositoryItem = prbLess80;
                else if (percent < 100)
                    e.RepositoryItem = prbLess99;
                else if (percent == 100)
                    e.RepositoryItem = prbLess100;
                else
                    e.RepositoryItem = prbLess101;
            }
        }
    }
}
