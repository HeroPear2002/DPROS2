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
using DTO;
using System.Globalization;
using System.Diagnostics;

namespace WareHouse.MachineRelationShip
{
    public partial class frmHistoryMainten : DevExpress.XtraEditors.XtraForm
    {
        public frmHistoryMainten()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadDateTime();
            KhoaDK();
        }
        void LoadDateTime()
        {
            DateTime today = DateTime.Now.Date;
            dtpkDate1.Value = today.AddDays(-(today.Day) + 1);
            dtpkDate2.Value = dtpkDate1.Value.AddMonths(1).AddDays(-1);
        }
        void LoadData()
        {
            DateTime date1 = dtpkDate1.Value;
            DateTime date2 = dtpkDate2.Value;
            int test = Kun_Static.HistoryMainten;
            if (test == 0)
            {
                this.Text = "lý lịch bảo dưỡng hàng ngày".ToUpper();
                GCData.DataSource = MachineDAO.Instance.GetListHistoryDevice(date1, date2);
            }
            else
            {
                this.Text = "lý lịch bảo dưỡng định kỳ".ToUpper();
                GCData.DataSource = MachineDAO.Instance.GetListHistoryDeviceLong(date1, date2);
            }
        }
        void KhoaDK()
        {
            icbStatus.Enabled = false;
            txtCount.Enabled = false;
            txtNote.Enabled = false;

            btnEdit.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            icbStatus.Enabled = true;
            txtCount.Enabled = true;
            txtNote.Enabled = true;

            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        void AddText()
        {
            try
            {
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtCount.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DataCount"]).ToString();

            }
            catch
            {
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                int Id = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Id"]).ToString());
                int status = MachineDAO.Instance.StatusHDById(Id);
                switch (status)
                {
                    case 4:
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    case 5:
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    case 6:
                        e.Appearance.BackColor = Color.Black;
                        e.Appearance.ForeColor = Color.White;
                        break;
                    default:
                        break;
                }
            }
        }

        private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MoKhoaDK();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Note = txtNote.Text;
            string count = txtCount.Text;
            DateTime dateCheck = dtpkDateCheck.Value.Date.AddHours(12);
            int statusHD = 0;
            int Id = 0;
            try
            {
                if (MessageBox.Show("bạn muốn sửa những thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (var item in gridView1.GetSelectedRows())
                    {
                        Id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                        statusHD = int.Parse(icbStatus.EditValue.ToString());
                        if (statusHD > 0)
                        {
                            MachineDAO.Instance.UpdateHistoryDevice(Id, count, statusHD, Note, dateCheck, icbStatus.Text);
                        }
                        else
                        {
                            statusHD = MachineDAO.Instance.StatusHistoryById(Id);
                            MachineDAO.Instance.UpdateHistoryDevice(Id, count, statusHD, Note, dateCheck, icbStatus.Text);
                        }
                    }
                    LoadControl();
                }

            }
            catch
            {
                MessageBox.Show("có lỗi khi sửa thông tin!\n\nbạn thử lại lần nữa nhé ".ToUpper());
            }

        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtNote.Text = ofd.FileName;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}