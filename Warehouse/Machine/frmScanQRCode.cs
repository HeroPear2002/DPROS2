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

namespace WareHouse.Machine
{
    public partial class frmScanQRCode : DevExpress.XtraEditors.XtraForm
    {
        public frmScanQRCode()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        int check = 0;
        void LoadControl()
        {
            this.AcceptButton = btnScan;
            this.CancelButton = btnExit;
            int check = Kun_Static.idCheck;
            if (check == 1)
            {
                txtNote.Text = "bạn đang chọn kiểm tra hàng ngày!".ToUpper();
            }
            else if (check == 2)
            {
                txtNote.Text = "bạn đang chọn kiểm tra định kỳ!".ToUpper();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Kun_Static.MachineCode.Length != 0)
            {
                LamMoi?.Invoke(sender, e);
            }
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                string qrCode = txtQrCode.Text;
                string[] array = qrCode.Split('&');
                string machineCode = array[0];
                int test = MachineDAO.Instance.TestMachineByCode(machineCode);
                if (test != -1)
                {
                    Kun_Static.MachineCode = machineCode;
                    if (Kun_Static.idCheck == 1)
                    {
                        frmEveryday f = new frmEveryday();
                        f.LamMoi += new EventHandler(btnUpdate_Click);
                        f.ShowDialog();
                        txtQrCode.Text = String.Empty;
                    }
                    else if (Kun_Static.idCheck == 2)
                    {
                        frmEveryMainten f = new frmEveryMainten();
                        f.LamMoi += new EventHandler(btnUpdate_Click);
                        f.ShowDialog();
                        txtQrCode.Text = String.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("mã vạch không đúng hoặc mã máy không tồn tại!".ToUpper(), "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("mã vạch không đúng!".ToUpper(), "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void frmScanQRCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Kun_Static.MachineCode.Length != 0 && check == 0)
            {
                LamMoi?.Invoke(sender, e);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            check = 1;
            this.Close();
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            Kun_Static.QrCodeMachine = "";
            frmScanCamera f = new frmScanCamera();
            f.ShowDialog();
            string Qr = Kun_Static.QrCodeMachine;
            txtQrCode.Text = Qr;
        }
    }
}