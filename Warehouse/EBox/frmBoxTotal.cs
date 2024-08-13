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
using DTO;

namespace WareHouse.EBox
{
    public partial class frmBoxTotal : Form
    {
        public frmBoxTotal()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            this.AcceptButton = btnView;
            frmBoxList f = new frmBoxList();
            txtBoxCode.Text = frmBoxList.BoxList.boxCode;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string BoxCode = txtBoxCode.Text;
            DateTime today = dtpkDate.Value.Date;
            DateTime DateCheck1 = today.AddHours(10);
            DateTime DateCheck2 = DateCheck1.AddDays(1);
            txtSLV.Text = BoxDAO.Instance.ToTalBoxByCode(BoxCode, DateCheck1, DateCheck2).ToString();
            txtTotalbox.Text = BoxDAO.Instance.ToTalBox(DateCheck1, DateCheck2).ToString();
        }
    }
}
