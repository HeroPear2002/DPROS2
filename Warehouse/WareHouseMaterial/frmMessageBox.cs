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
    public partial class frmMessageBox : DevExpress.XtraEditors.XtraForm
    {
        public frmMessageBox()
        {
            InitializeComponent();
            LoadMessege();
        }
        void LoadMessege()
        {
            //this.ControlBox = false;
            lblMesage.Text = Kun_Static.MessageBoxDetail;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Kun_Static.MessageBoxValue = 1;
            Kun_Static.MessageBoxDetail = "";
            this.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Kun_Static.MessageBoxValue = 0;
            Kun_Static.MessageBoxDetail = "";
            this.Close();
        }
    }
}