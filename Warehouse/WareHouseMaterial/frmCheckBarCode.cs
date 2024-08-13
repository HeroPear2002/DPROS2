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
    public partial class frmCheckBarCode : DevExpress.XtraEditors.XtraForm
    {
        public frmCheckBarCode()
        {
            InitializeComponent();
            txtTem2.Focus();
        }
        int check = 0;
        void LoadControl()
        {
            txtTem2.Focus();
            
        }
        private void txtTem2_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = 200;
            timer1.Start();
            check = 0;
        }

        private void txtTem3_TextChanged(object sender, EventArgs e)
        {
            check = 1;
            timer1.Interval = 300;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(check == 0)
            {
                txtTem3.Focus();
                txtTem3.SelectAll();
                timer1.Stop();
            }
            else
            {
                string []tem2 = txtTem2.Text.Split('&');
                string []tem3 = txtTem3.Text.Split('&');
                string check2 = tem2[0] + "&" + tem2[1];
                string check3 = tem3[0] +"&"+ tem3[1];
                if(tem3.Count() <= 3)
                {
                    timer1.Stop();
                    var body = "<size=14><b><color=255, 0, 0>mã vạch không khớp bạn hãy kiểm tra lại</color></size></b>";
                    XtraMessageBox.Show(body.ToUpper(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
                    return;
                }
                if(check2 != check3)
                {
                    timer1.Stop();
                    var body = "<size=14><b><color=255, 0, 0>mã vạch không khớp bạn hãy kiểm tra lại</color></size></b>";
                    XtraMessageBox.Show(body.ToUpper(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
                 
                    return;
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}