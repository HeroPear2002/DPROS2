using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.PCGridControl
{
    public partial class frmEndSX : Form
    {
        public frmEndSX()
        {
            InitializeComponent();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            string BarCode = txtBarCode.Text.ToUpper();
            string[] arrayList = BarCode.Split('&');
            int leng = arrayList.Count();
            if (leng == 4)
            {
                txtPartCode.Text = arrayList[0];
                txtMachine.Text = arrayList[1];
                txtMoldNumber.Text = arrayList[2];
            }
            else
            {
                txtPartCode.Text = arrayList[3];
                txtMachine.Text = arrayList[9];
                string moldSTR = arrayList[8];
                bool a = moldSTR.Contains("-");
                if (a == true)
                {
                    string[] array = moldSTR.Split('-');
                    txtMoldNumber.Text = array[0];
                }
                else
                {
                    txtMoldNumber.Text = moldSTR;
                }
            }
            string machineCode = txtMachine.Text;
            string partCode = txtPartCode.Text;
            string mold = txtMoldNumber.Text;
            List<TableSX> listT = TDSXDAO.Instance.GetListTableSX().Where(x => x.MachineCode == machineCode).Where(y => y.PartCode == partCode).Where(z => z.MoldNumber == mold).Where(m => m.ConfirmSX == 1).ToList();
            GCData.DataSource = listT;
        }
        void AddText()
        {
            try
            {
                dtpkEnd.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EndTime"]).ToString();
                dtpkStart.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["StartTime"]).ToString();
                nudQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Quantity"]).ToString();
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch 
            {
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            AddText();
        }

        private void frmEndSX_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadControl();
            timer1.Stop();
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string machineCode = txtMachine.Text;
            string partCode = txtPartCode.Text;
            string mold = txtMoldNumber.Text;
            int Quantity = (int)nudQuantity.Value;
            long id = long.Parse(txtID.Text);
            long IdTT = TDSXDAO.Instance.IDTableTT(id);
            DateTime MaxEndTimeTT = TDSXDAO.Instance.MaxEndTimeTTByIdSX(id);
            int idResourceXH = TDSXDAO.Instance.IdResourceXH(id);
            int idResourceDK = TDSXDAO.Instance.IdResourceDK(id);
            DateTime MaxEndtimeDK = TDSXDAO.Instance.MaxEndTimeDK(id);
            DateTime MaxEndtimeXH = TDSXDAO.Instance.MaxEndTimeXH(id);
            string employess = txtEmployess.Text;
            int test = EmployessDAO.Instance.TestEmployessByCode(employess);
            if (test == -1)
            {
                MessageBox.Show("mã nhân viên không đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Quantity == 0)
            {
                MessageBox.Show("bạn chưa điền số lượng lin kiện cần sản xuất !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime start = (DateTime)dtpkStart.Value;
            DateTime end = dtpkEnd.Value;
            if(end <= start || end < MaxEndTimeTT)
            {
                MessageBox.Show("thời gian kết thúc không đúng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TDSXDAO.Instance.UpdateTableSX(id, Quantity, end, 6, 0);
            TDSXDAO.Instance.UpdateMaxTimeTableTT(IdTT, end);
            if (end < MaxEndtimeDK)
            {
                TDSXDAO.Instance.DeleteTableDKByDate(end.AddMinutes(-5), id);
            }
            else if (end > MaxEndtimeDK)
            {
                if ((end - MaxEndtimeDK).TotalHours >= 2)
                {
                    int n = (int)Math.Floor(((end - MaxEndtimeDK).TotalHours) / 2);
                    // Thêm kiểm tra định kỳ
                    for (int i = 1; i <= n; i++)
                    {
                        TDSXDAO.Instance.InsertTableDK(idResourceDK, id, MaxEndtimeDK.AddHours(i * 2), MaxEndtimeDK.AddHours(i * 2).AddMinutes(5), 8, 1, MaxEndtimeDK.AddHours((i + 1) * 2), employess);
                    }
                }

            }
            if (end < MaxEndtimeXH)
            {
         
                TDSXDAO.Instance.DeleteTableXHByDate(end.AddMinutes(-10), id);
                TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
            }
            else if (end > MaxEndtimeXH)
            {
                TDSXDAO.Instance.DeleteTableXHByDate(MaxEndtimeXH.AddMinutes(5), id);
                int m = (int)Math.Ceiling(((end - MaxEndtimeXH).TotalHours) / 12);
                double k = ((end - MaxEndtimeXH).TotalHours);
                if (k <= 12)
                {
                    TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
                }
                else
                {
                    for (int i = 1; i <= m; i++)
                    {
                        if (i != m)
                        {
                            TDSXDAO.Instance.InsertTableXH(idResourceXH, id, MaxEndtimeXH.AddHours(12 * i), MaxEndtimeXH.AddHours(12 * i).AddMinutes(5), 8, 1, MaxEndtimeXH.AddHours(12 * i).AddHours(12), employess);
                        }
                        else
                        {
                            TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
                        }
                    }
                }
            }
            MessageBox.Show("Cập nhật thành công !".ToUpper());
            try
            {
                string xh = PartDAO.Instance.XH(partCode);
                Process.Start(xh);
            }
            catch
            {
                MessageBox.Show("mã linh kiện chưa có Form xuất hàng".ToUpper());
            }
            this.Close();
        }
    }
}
