using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DAO;

namespace WareHouse.PCGridControl
{
    public partial class frmListTableTT : DevExpress.XtraEditors.XtraForm
    {
        public frmListTableTT()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            LoadDate();
        }
        void LoadData()
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            GCData.DataSource = ListTableDAO.Instance.ListTableTTByDate(date1, date2);
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now;
            dtpkFrom.Value = today.Date.AddDays(-(today.Day - 1));
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddSeconds(-1);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                long id = int.Parse(txtID.Text);
                DateTime StartTime = (DateTime)dtpkFrom.Value;
                DateTime EndTime = (DateTime)dtpkTo.Value;
                ListTableDAO.Instance.EditTableTT(id, StartTime, EndTime);
                LoadControl();
            }
            catch
            {
                MessageBox.Show("Có lối khi Lưu \nBạn hãy lưu lại !".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                DateTime startTime = DateTime.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StartTime"]).ToString());
                DateTime endTime = DateTime.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["EndTime"]).ToString());
                if (endTime <= startTime)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                dtpkFrom.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["StartTime"]).ToString();
                dtpkTo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EndTime"]).ToString();
            }
            catch
            {
            }
        }
    }
}