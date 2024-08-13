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
using WareHouse.PO_and_Order;
using DTO;
using DAO;

namespace WareHouse.MacCheck
{
    public partial class frmPOCheck : DevExpress.XtraEditors.XtraForm
    {
        Timer timer1;
        public frmPOCheck()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        string _checkCode = Kun_Static.CheckCode;
        void LoadControl()
        {
            timer1 = new Timer();
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            txtPOCode.Focus();
            txtPOCode.SelectAll();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            LoadData();
           
        }
        void LoadData()
        {
            string str = txtPOCode.Text;
            if(str.ToUpper() == "YES")
            {
                timer1.Stop();
                txtPOCode.SelectAll();
            }
            if(! str.Contains(' '))
            {
                timer1.Stop();
                MessageBox.Show("mã vạch không đúng".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPOCode.SelectAll();
                return;
            }
            string[] array = txtPOCode.Text.Split(' ');
            string barCode = "";
            if (array.Count() == 2)
            {
                barCode = array[0];
            }
            else
            {
                barCode = array[4];
            }
            string poCode = barCode.Substring(3,barCode.Length-3);
            List<CheckDeliveryDTO> listC = BoxCheckDAO.Instance.GetCheckDeliveryDTOsPOCode(_checkCode,poCode);
            if(listC.Count == 0)
            {
                timer1.Stop();
                MessageBox.Show("PO đã được xuất hoặc không có PO này".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPOCode.SelectAll();
                return;
            }
            if(listC.Count(x=>x.StatusCheck != 1) == 0)
            {
                timer1.Stop();
                MessageBox.Show("PO đã được xuất hoặc không có PO này".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPOCode.SelectAll();
                return;
            }
            Kun_Static.POCode = poCode;
            frmBoxCheck f = new frmBoxCheck();
            f.LamMoi += new EventHandler(btn_Click);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            List<CheckDeliveryDTO> listC = new List<CheckDeliveryDTO>();
            listC = BoxCheckDAO.Instance.GetCheckDeliveryDTOs(_checkCode, 1);
            if (listC.Count > 0)
            {
                MessageBox.Show("bạn chưa check hết số lượng.".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
            }
        }

        private void txtPOCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}