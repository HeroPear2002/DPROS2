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

namespace WareHouse.WareHouseMaterial
{
    public partial class frmReasonCTSX : DevExpress.XtraEditors.XtraForm
    {
        public frmReasonCTSX()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadReason();
        }
        void LoadReason()
        {
            cbReason.DataSource = MaterialDAO.Instance.GetReason("B");
            cbReason.DisplayMember = "ReasonDetail";
            cbReason.ValueMember = "ReasonDetail";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string reason = cbReason.Text;
            if(reason.Trim().Length == 0)
            {
                MessageBox.Show("bạn chưa chọn lý do!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Kun_Static.CheckOutMateial = 1;
                Kun_Static.NoteCTSX = reason;
                this.Close(); 
            }
        }

        private void frmReasonCTSX_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void frmReasonCTSX_FormClosed(object sender, FormClosedEventArgs e)
        {
   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Kun_Static.CheckOutMateial = 0;
            this.Close();
        }
    }
}