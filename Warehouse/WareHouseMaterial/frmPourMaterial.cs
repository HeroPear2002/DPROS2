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

namespace WareHouse.WareHouseMaterial
{
    public partial class frmPourMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmPourMaterial()
        {
            InitializeComponent();
            LoadControl();
        }
        int _check = 0;
        void LoadControl()
        {
            txtKanban.Focus();
            btnSave.Enabled = false;
        }
        void LoadData()
        {
            string barCode = txtKanban.Text;
            string materialCode = Kun_Static.outputMaterial.MaterialCode;
            if (barCode.ToUpper() == materialCode.ToUpper())
            {
                btnSave.Enabled = true;
                _check = 1;
                CheckPourMaterial.check = _check;
                this.Close();
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Loại nguyên liệu không đúng,cần xác nhận lại".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckPourMaterial.check = _check;
            this.Close();
        }
        private void txtKanban_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadData();
            timer1.Stop();
        }
        public class CheckPourMaterial
        {
            public static int check = 0;
        }
        private void frmPourMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckPourMaterial.check = _check;
        }
    }
}