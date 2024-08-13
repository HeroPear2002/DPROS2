using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmMessage : Form
    {
        public frmMessage()
        {
            InitializeComponent();
        }
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
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
