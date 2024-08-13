using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouse.Model;
using System.Threading;

namespace WareHouse.PC
{
    public partial class frmProgress : DevExpress.XtraEditors.XtraForm
    {
        public frmProgress()
        {
            InitializeComponent();
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}