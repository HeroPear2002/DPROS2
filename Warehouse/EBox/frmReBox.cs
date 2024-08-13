using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace WareHouse.EBox
{
    public partial class frmReBox : Form
    {
        public frmReBox()
        {
            InitializeComponent();
        }
        public EventHandler LamMoi;
       
        private void txtBoxCode_TextChanged(object sender, EventArgs e)
        {
            

        }
        void XoaText(object sender, EventArgs e)
        {
            this.Invoke(
            new MethodInvoker(() =>
            {
             
                txtBoxCode1.Text = String.Empty;
            }));

        }
      

        private void frmReBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void txtBoxCode1_EditValueChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = DateTime.Now;
            string BoxCode = txtBoxCode1.Text;
            int Test = BoxDAO.Instance.TestBoxList(BoxCode);
            int Iventory = BoxDAO.Instance.IventoryBoxList(BoxCode);
            if (Test == 1)
            {
                BoxDAO.Instance.UpdateIventoryListBox(BoxCode, (Iventory + 1));
                BoxDAO.Instance.InsertReBox(BoxCode, today);
                LamMoi?.Invoke(sender, e);
            }
            else
            {
             
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBoxCode1.Text = String.Empty;
            timer1.Stop();
        }
    }
}
