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
using DAO;
using System.Globalization;
using System.Diagnostics;

namespace WareHouse.PCGridControl
{
    public partial class frmTableSX : DevExpress.XtraEditors.XtraForm
    {
        public frmTableSX()
        {
            InitializeComponent();
            LoadDate();
        }
        public EventHandler LamMoi;
        void LoadDate()
        {
            DateTime today = DateTime.Now;
            dtpkStart.Value = today;
            dtpkEnd.Value = today;
        }
        void LoadTableSX()
        {
            string BarCode = txtBarCode.Text;
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
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string machineCode = txtMachine.Text;
            string partCode = txtPartCode.Text;
            if(PartDAO.Instance.TestPartByCode(partCode) == -1)
            {
                MessageBox.Show("mã linh kiện không chính xác !".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mold = txtMoldNumber.Text;
            int Quantity = (int)nudQuantity.Value;
            string employess = txtEmployess.Text;
            int test = EmployessDAO.Instance.TestEmployessByCode(employess);
            if (test == -1)
            {
                MessageBox.Show("mã nhân viên không đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             DateTime MaxEntime = TDSXDAO.Instance.MaxEndTimeSX(machineCode);
            if (Quantity ==0)
            {
                MessageBox.Show("bạn chưa điền số lượng linh kiện cần sản xuất !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int Cav = PartDAO.Instance.CavityByCode(partCode);
            int second = (int)((Quantity *PartDAO.Instance.CycleTimeByCode(partCode))/Cav);
            DateTime start = (DateTime)dtpkStart.Value;
            DateTime end = start.AddSeconds(second);
            int idPerent = ResoucesDAO.Instance.IdResourceByDES(0, machineCode);
            int confirm = TDSXDAO.Instance.ConfirmSX(machineCode);
            if(confirm != -1)
            {
                MessageBox.Show("máy đúc đang chạy một mã linh kiện khác!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(start < MaxEntime)
            {
                MessageBox.Show("bạn hãy kiểm tra lại thời gian bắt đầu sản xuất!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(idPerent != -1)
            {
                int idResourceSX = ResoucesDAO.Instance.IdResourceByDES(idPerent, "1.Sản xuất");
                int idResourceTT = ResoucesDAO.Instance.IdResourceByDES(idPerent, "2.Thực tế");
                int idResourceDK = ResoucesDAO.Instance.IdResourceByDES(idPerent, "3.Định kỳ");
                int idResourceXH = ResoucesDAO.Instance.IdResourceByDES(idPerent, "4.Xuất hàng");
                TDSXDAO.Instance.InsertTableSX(idResourceSX, machineCode, mold, partCode, start, end, Quantity, 3, 1, employess);
                long MaxIdSX = TDSXDAO.Instance.MaxIdTableSX();
                TDSXDAO.Instance.InsertTableTT(idResourceTT, MaxIdSX, start, start.AddMinutes(5), 0, 4, 1,end,"");
                int n = (int)Math.Floor(((end - start).TotalHours)/2);
                // Thêm kiểm tra định kỳ
                for (int i = 0; i <= n; i++)
                {
                    if(i==0)
                    {
                        TDSXDAO.Instance.InsertTableDK(idResourceDK, MaxIdSX, start.AddHours(i * 2), start.AddHours(i * 2).AddMinutes(5), 10, 2, start.AddHours((i + 1) * 2), employess);
                    }
                    else
                    {
                        TDSXDAO.Instance.InsertTableDK(idResourceDK, MaxIdSX, start.AddHours(i*2), start.AddHours(i * 2).AddMinutes(5), 8, 1, start.AddHours((i+1) * 2), employess);
                    }
                    
                    
                }
                int m = (int)Math.Ceiling(((end - start).TotalHours) / 12);
                double k = ((end - start).TotalHours);
                TDSXDAO.Instance.InsertTableXH(idResourceXH, MaxIdSX, start, start.AddMinutes(5), 10, 2, start.AddHours(12).AddHours(12), employess);
                if (k<=12)
                {
                    TDSXDAO.Instance.InsertTableXH(idResourceXH, MaxIdSX, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
                }
                else
                {
                    for (int i = 1; i <= m; i++)
                    {
                        if(i != m)
                        {
                            TDSXDAO.Instance.InsertTableXH(idResourceXH, MaxIdSX, start.AddHours(12*i), start.AddHours(12*i).AddMinutes(5), 8, 1, start.AddHours(12 * i).AddHours(12), employess);
                        }
                        else
                        {
                            TDSXDAO.Instance.InsertTableXH(idResourceXH, MaxIdSX, end.AddMinutes(-5), end, 8, 1,end.AddHours(12), employess);
                        }
                    }
                }
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                try
                {
                    string ld = PartDAO.Instance.LD(partCode);
                    Process.Start(ld);
                }
                catch 
                {
                    MessageBox.Show("mã linh kiện chưa có Form lượt đầu".ToUpper());
                }
            }
            else
            {
                MessageBox.Show("có lỗi khi thêm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadTableSX();
            timer1.Stop();
        }
        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void frmTableSX_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}